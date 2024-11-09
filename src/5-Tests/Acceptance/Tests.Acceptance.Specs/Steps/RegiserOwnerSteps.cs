using FluentAssertions;
using Suzianna.Core.Screenplay;
using TaskoMask.Tests.Acceptance.Core.Helpers;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TaskoMask.Tests.Acceptance.Specs.Steps;

[Binding]
public class RegiserOwnerSteps
{
    #region Fields

    private readonly Stage _stage;
    private OwnerRegisterDto ownerRegisterDto;

    #endregion

    #region Ctor

    /// <summary>
    ///
    /// </summary>
    /// <param name="stage"> Initialized by TestsBaseHook</param>
    public RegiserOwnerSteps(Stage stage)
    {
        _stage = stage;
    }

    #endregion

    #region Scenario: Registering online for a new owner account



    [Given(@"John is not a registered member")]
    public void GivenJohnIsNotARegisteredMember()
    {
        _stage.ShineSpotlightOn("John");
    }

    [When(@"John registers for a new account")]
    public void WhenJohnRegistersForANewAccount(Table table)
    {
        ownerRegisterDto = table.CreateInstance<OwnerRegisterDto>();
        _stage.ActorInTheSpotlight.AttemptsTo(Perform.RegisterOwner(ownerRegisterDto));
    }

    [When(@"John attempts to login")]
    public void WhenJohnAttemptsToLogin()
    {
        var ownerLoginDto = new OwnerLoginDto { UserName = ownerRegisterDto.Email, Password = ownerRegisterDto.Password };

        _stage.ActorInTheSpotlight.AttemptsTo(Perform.LoginOwner(ownerLoginDto));
    }

    [Then(@"John login successfully")]
    public void ThenJohnLoginSuccessfully()
    {
        var registerResult = _stage.ActorInTheSpotlight.Recall<bool>(MagicKey.Owner.REGISER_RESULT);
        var loginResult = _stage.ActorInTheSpotlight.Recall<bool>(MagicKey.Owner.LOGIN_RESULT);
        registerResult.Should().BeTrue();
        loginResult.Should().BeTrue();
    }

    [Then(@"John has access to his profile")]
    public void ThenJohnHasAccessToHisProfile()
    {
        var lastOwnerResult = _stage.ActorInTheSpotlight.AsksFor(DataFrom.LastOwner());
        lastOwnerResult.IsSuccess.Should().BeTrue();
        lastOwnerResult.Value.Email.Should().Be(ownerRegisterDto.Email);
    }

    #endregion

    #region Scenario: Preventing registration with duplicate email



    [Given(@"John is a registered member")]
    public void GivenJohnIsARegisteredMember(Table table)
    {
        _stage.ShineSpotlightOn("John");

        ownerRegisterDto = table.CreateInstance<OwnerRegisterDto>();

        _stage.ActorInTheSpotlight.AttemptsTo(Perform.RegisterOwner(ownerRegisterDto));
    }

    [Given(@"Jane is not a registered member")]
    public void GivenJaneIsNotARegisteredMember()
    {
        _stage.ShineSpotlightOn("Jane");
    }

    [When(@"Jane registers for a new account with John's email")]
    public void WhenJaneRegistersForANewAccountWithJohnsEmail(Table table)
    {
        ownerRegisterDto = table.CreateInstance<OwnerRegisterDto>();
        _stage.ActorInTheSpotlight.AttemptsTo(Perform.RegisterOwner(ownerRegisterDto));
    }

    [Then(@"Jane can not register")]
    public void ThenJaneCanNotRegister()
    {
        var registerResult = _stage.ActorInTheSpotlight.Recall<bool>(MagicKey.Owner.REGISER_RESULT);
        registerResult.Should().BeFalse();
    }

    #endregion
}

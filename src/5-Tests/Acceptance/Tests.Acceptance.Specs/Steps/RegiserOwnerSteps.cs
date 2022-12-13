using FluentAssertions;
using Suzianna.Core.Screenplay;
using TaskoMask.Tests.Acceptance.Core.Helpers;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TaskoMask.Tests.Acceptance.Specs.Steps
{
    [Binding]
    public class RegiserOwnerSteps
    {
        #region Fields

        private Stage _stage;
        private OwnerRegisterDto _ownerRegisterDto;

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
            _ownerRegisterDto = table.CreateInstance<OwnerRegisterDto>();
            _stage.ActorInTheSpotlight.AttemptsTo(Perform.RegisterOwner(_ownerRegisterDto));
        }



        [When(@"John attempts to login")]
        public void WhenJohnAttemptsToLogin()
        {
            var ownerLoginDto = new OwnerLoginDto
            {
                UserName = _ownerRegisterDto.Email,
                Password = _ownerRegisterDto.Password,
            };

            _stage.ActorInTheSpotlight.AttemptsTo(Perform.LoginOwner(ownerLoginDto));
        }



        [Then(@"John login successfully")]
        public void ThenJohnLoginSuccessfully()
        {
            var registerResult = _stage.ActorInTheSpotlight.Recall<bool>(MagicKey.Owner.Regiser_Result);
            var loginResult = _stage.ActorInTheSpotlight.Recall<bool>(MagicKey.Owner.Login_Result);
            registerResult.Should().BeTrue();
            loginResult.Should().BeTrue();
        }



        [Then(@"John has access to his profile")]
        public void ThenJohnHasAccessToHisProfile()
        {
            var lastOwnerResult = _stage.ActorInTheSpotlight.AsksFor(DataFrom.LastOwner());
            lastOwnerResult.IsSuccess.Should().BeTrue();
            lastOwnerResult.Value.Email.Should().Be(_ownerRegisterDto.Email);
        }



        #endregion

        #region Scenario: Preventing registration with duplicate email



        [Given(@"John is a registered member")]
        public void GivenJohnIsARegisteredMember(Table table)
        {
            _stage.ShineSpotlightOn("John");

            _ownerRegisterDto = table.CreateInstance<OwnerRegisterDto>();

            _stage.ActorInTheSpotlight.AttemptsTo(Perform.RegisterOwner(_ownerRegisterDto));
        }



        [Given(@"Jane is not a registered member")]
        public void GivenJaneIsNotARegisteredMember()
        {
            _stage.ShineSpotlightOn("Jane");
        }



        [When(@"Jane registers for a new account with John's email")]
        public void WhenJaneRegistersForANewAccountWithJohnsEmail(Table table)
        {
            _ownerRegisterDto = table.CreateInstance<OwnerRegisterDto>();
            _stage.ActorInTheSpotlight.AttemptsTo(Perform.RegisterOwner(_ownerRegisterDto));
        }



        [Then(@"Jane can not register")]
        public void ThenJaneCanNotRegister()
        {
            var registerResult = _stage.ActorInTheSpotlight.Recall<bool>(MagicKey.Owner.Regiser_Result);
            registerResult.Should().BeFalse();
        }



        #endregion

    }
}

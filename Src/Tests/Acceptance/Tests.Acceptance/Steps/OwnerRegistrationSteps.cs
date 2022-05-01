using FluentAssertions;
using Suzianna.Core.Screenplay;
using Suzianna.Rest.Screenplay.Abilities;
using System.Collections.Generic;
using TaskoMask.Tests.Acceptance.Share.Helpers;
using TaskoMask.Tests.Acceptance.Models.Owners;
using TaskoMask.Tests.Acceptance.Screenplay.Owners.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TaskoMask.Tests.Acceptance.Steps
{
    [Binding]
    public class OwnerRegistrationSteps
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
        public OwnerRegistrationSteps(Stage stage)
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
        public void WhenJohnRegistersForANewAccountWithHisEmail(Table table)
        {
            _ownerRegisterDto = table.CreateInstance<OwnerRegisterDto>();
            _stage.ActorInTheSpotlight.AttemptsTo(new RegisterOwnerTask(_ownerRegisterDto));
        }



        [When(@"John attempts to Log in")]
        public void WhenJohnAttemptsToLogIn()
        {
            var ownerLoginDto = new OwnerLoginDto
            {
                UserName = _ownerRegisterDto.Email,
                Password = _ownerRegisterDto.Password,
            };

            _stage.ActorInTheSpotlight.AttemptsTo(new LoginOwnerTask(ownerLoginDto));
        }



        [Then(@"John log in successfully")]
        public void ThenJohnLogInSuccessfully()
        {
            var loginResult = _stage.ActorInTheSpotlight.Recall<Result<UserJwtTokenDto>>(MagicKey.Owner.Login_Result);
            loginResult.IsSuccess.Should().BeTrue();
        }



        #endregion

        #region Scenario: Preventing registration with duplicate email



        [Given(@"John is a registered member")]
        public void GivenJohnIsARegisteredMember(Table table)
        {
            _stage.ShineSpotlightOn("John");

            _ownerRegisterDto = table.CreateInstance<OwnerRegisterDto>();

            _stage.ActorInTheSpotlight.AttemptsTo(new RegisterOwnerTask(_ownerRegisterDto));
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
            _stage.ActorInTheSpotlight.AttemptsTo(new RegisterOwnerTask(_ownerRegisterDto));
        }



        [Then(@"Jane can not register")]
        public void ThenJaneCanNotRegister()
        {
            var registerResult = _stage.ActorInTheSpotlight.Recall<Result<UserJwtTokenDto>>(MagicKey.Owner.Regiser_Result);
            registerResult.IsSuccess.Should().BeFalse();
        }



        #endregion

    }
}

using FluentAssertions;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Abilities;
using TaskoMask.Tests.Acceptance.Helpers;
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

        private Actor _john;
        private Actor _jane;
        private OwnerRegisterDto _ownerRegisterDto;

        #endregion

        #region Ctor

        public OwnerRegistrationSteps()
        {

        }

        #endregion

        #region Scenario: Registering online for a new owner account



        [Given(@"John is not a registered member")]
        public void GivenJohnIsNotARegisteredMember()
        {
            _john = Actor.Named("John").WhoCan(CallAnApi.At("https://localhost:44314/"));
        }



        [When(@"John registers for a new account")]
        public void WhenJohnRegistersForANewAccountWithHisEmail(Table table)
        {
            _ownerRegisterDto = table.CreateInstance<OwnerRegisterDto>();
            _john.AttemptsTo(new RegisterOwnerTask(_ownerRegisterDto));
        }



        [When(@"John attempts to Log in")]
        public void WhenJohnAttemptsToLogIn()
        {
            var ownerLoginDto = new OwnerLoginDto
            {
                UserName = _ownerRegisterDto.Email,
                Password = _ownerRegisterDto.Password,
            };

            _john.AttemptsTo(new LoginOwnerTask(ownerLoginDto));
        }



        [Then(@"John log in successfully")]
        public void ThenJohnLogInSuccessfully()
        {
            var loginResult = _john.Recall<Result<UserJwtTokenDto>>(MagicKey.Owner.Login_Result);
            loginResult.IsSuccess.Should().BeTrue();
        }



        #endregion

        #region Scenario: Preventing registration with duplicate email




        [Given(@"Jane is not a registered member")]
        public void GivenJaneIsNotARegisteredMember()
        {
        }



        [When(@"Jane registers for a new account with John's email")]
        public void WhenJaneRegistersForANewAccountWithJohnsEmail(Table table)
        {
        }



        [Then(@"Jane can not register")]
        public void ThenJaneCanNotRegister()
        {
        }



        [Then(@"Jane is not in owners List")]
        public void ThenJaneIsNotInOwnersList()
        {
        }



        #endregion

    }
}

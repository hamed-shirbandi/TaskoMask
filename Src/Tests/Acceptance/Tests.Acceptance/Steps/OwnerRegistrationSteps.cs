using System;
using TechTalk.SpecFlow;

namespace TaskoMask.Tests.Acceptance.Steps
{
    [Binding]
    public class OwnerRegistrationSteps
    {
        #region Fields



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
            throw new PendingStepException();
        }



        [When(@"John registers for a new account with his email")]
        public void WhenJohnRegistersForNewAccount()
        {
            throw new PendingStepException();
        }



        [Then(@"Joun can login")]
        public void ThenJounCanLogin()
        {
            throw new PendingStepException();
        }



        [Then(@"John can see the dashboard data")]
        public void ThenJohnCanSeeTheDashboardData()
        {
            throw new PendingStepException();
        }



        #endregion

        #region Scenario: Preventing registration with duplicate email



        [Given(@"Jane is not a registered member")]
        public void GivenJaneIsNotARegisteredMember()
        {
            throw new PendingStepException();
        }



        [When(@"Jane registers for a new account with john's email")]
        public void WhenJaneRegistersForANewAccountWithJohnsEmail()
        {
            throw new PendingStepException();
        }



        [Then(@"Jane can not register")]
        public void ThenJaneCanNotRegister()
        {
            throw new PendingStepException();
        }



        #endregion

    }
}

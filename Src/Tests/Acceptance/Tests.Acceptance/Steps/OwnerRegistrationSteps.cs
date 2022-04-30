using System;
using TechTalk.SpecFlow;

namespace TaskoMask.Tests.Acceptance.Steps
{
    [Binding]
    public class OwnerRegistrationSteps
    {
        [Given(@"John is not a registered member")]
        public void GivenJohnIsNotARegisteredMember()
        {
            throw new PendingStepException();
        }

        [When(@"John registers for new account")]
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
    }
}

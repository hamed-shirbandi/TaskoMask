using Suzianna.Rest.OAuth;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Questions;

namespace TaskoMask.Tests.Acceptance.API.Screenplay.Questions
{
    public class OwnerDetailsApiQuestion : OwnerDetailsQuestion
    {
        private string _token;
        public OwnerDetailsApiQuestion(string ownerId,string token) : base(ownerId)
        {
            _token = token;
        }

        protected override OwnerDetailsDto GetOwnerDetails<T>(T actor)
        {
            actor.Remember(TokenConstants.TokenKey, _token);
            actor.AttemptsTo(Get.ResourceAt($"owners/{OwnerId}"));
            return actor.AsksFor(LastResponse.Content<OwnerDetailsDto>());
        }
    }
}

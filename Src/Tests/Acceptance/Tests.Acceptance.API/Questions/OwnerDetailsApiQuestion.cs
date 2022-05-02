using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Share.Models;
using TaskoMask.Tests.Acceptance.Share.Screenplay.Questions;

namespace TaskoMask.Tests.Acceptance.API.Screenplay.Questions
{
    public class OwnerDetailsApiQuestion : OwnerDetailsQuestion
    {
        //usage : 
        public OwnerDetailsApiQuestion(string ownerId) : base(ownerId)
        {

        }

        protected override OwnerDetailsDto GetOwnerDetails<T>(T actor)
        {
            actor.AttemptsTo(Get.ResourceAt($"owners/{OwnerId}"));
            return actor.AsksFor(LastResponse.Content<OwnerDetailsDto>());
        }
    }
}

using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Core.Helpers;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Questions;

namespace TaskoMask.Tests.Acceptance.API.Questions
{
    public class LastOwnerApiQuestion : LastOwnerQuestion
    {
        public LastOwnerApiQuestion()
        {

        }
        protected override Result<OwnerBasicInfoDto> GetLastOwner<T>(T actor)
        {
            actor.AttemptsTo(Get.ResourceAt($"owner"));
            return actor.AsksFor(LastResponse.Content<Result<OwnerBasicInfoDto>>());
        }
    }
}

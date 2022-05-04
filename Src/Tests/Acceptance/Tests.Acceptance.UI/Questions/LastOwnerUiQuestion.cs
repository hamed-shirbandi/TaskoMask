
using TaskoMask.Tests.Acceptance.Core.Helpers;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Questions;

namespace TaskoMask.Tests.Acceptance.UI.Questions
{
    public class LastOwnerUiQuestion : LastOwnerQuestion
    {
        public LastOwnerUiQuestion()
        {

        }
        protected override Result<OwnerBasicInfoDto> GetLastOwner<T>(T actor)
        {
            //TODO: Get data from web page by selenium drivers

            return Result.Failure<OwnerBasicInfoDto>();
        }
    }
}


using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Questions;

namespace TaskoMask.Tests.Acceptance.UI.Questions
{
    public class LastOwnerUiQuestion : LastOwnerQuestion
    {
        public LastOwnerUiQuestion()
        {

        }
        protected override OwnerBasicInfoDto GetLastOwner<T>(T actor)
        {
            //TODO: Get data from web page by selenium drivers

            return new OwnerBasicInfoDto
            {

            };
        }
    }
}

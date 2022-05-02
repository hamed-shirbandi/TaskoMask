using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Share.Models;
using TaskoMask.Tests.Acceptance.Share.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Share.Screenplay.Tasks;

namespace TaskoMask.Tests.Acceptance.Screenplay
{
    public static class Perform
    {
        public static ITask LoginOwner(OwnerLoginDto ownerLoginDto)
        {
            return Factory.CreateTask<LoginOwnerTask>(ownerLoginDto);
        }


        public static ITask RegisterOwner(OwnerRegisterDto ownerRegisterDto)
        {
            return Factory.CreateTask<RegisterOwnerTask>(ownerRegisterDto);

        }


        public static IQuestion<OwnerDetailsDto> OwnerDetails(string ownerId)
        {
            //usage in steps : 
            //var dto= actor.AsksFor(new OwnerDetailsApiQuestion(ownerId));

            return Factory.CreateQuestion<OwnerDetailsQuestion>(ownerId);
        }
    }
}

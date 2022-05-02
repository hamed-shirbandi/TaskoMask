using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Tasks;

namespace TaskoMask.Tests.Acceptance.Core.Screenplay
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

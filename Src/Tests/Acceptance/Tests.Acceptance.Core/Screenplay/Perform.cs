using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Tasks;

namespace TaskoMask.Tests.Acceptance.Core.Screenplay
{

    /// <summary>
    /// It is used just to bring out technical decisions from spec definitions
    /// So it helps us to chose between API or UI level to run the tests without modifing the spec definition class
    /// </summary>
    public static class Perform
    {

        /// <summary>
        /// 
        /// </summary>
        public static ITask LoginOwner(OwnerLoginDto ownerLoginDto)
        {
            return Factory.CreateTask<LoginOwnerTask>(ownerLoginDto);
        }



        /// <summary>
        /// 
        /// </summary>
        public static ITask RegisterOwner(OwnerRegisterDto ownerRegisterDto)
        {
            return Factory.CreateTask<RegisterOwnerTask>(ownerRegisterDto);

        }



        /// <summary>
        /// 
        /// </summary>
        public static IQuestion<OwnerDetailsDto> OwnerDetails(string ownerId)
        {
            //usage in steps : 
            //var dto= actor.AsksFor(new OwnerDetailsApiQuestion(ownerId));

            return Factory.CreateQuestion<OwnerDetailsQuestion>(ownerId);
        }
    }
}

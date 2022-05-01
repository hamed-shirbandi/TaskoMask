using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using TaskoMask.Tests.Acceptance.Share.Helpers;
using TaskoMask.Tests.Acceptance.Share.Models;

namespace TaskoMask.Tests.Acceptance.Share.Tasks
{
    public class RegisterOwnerTask : ITask
    {
        private readonly OwnerRegisterDto _ownerRegisterDto;

        public RegisterOwnerTask(OwnerRegisterDto ownerRegisterDto)
        {
            _ownerRegisterDto = ownerRegisterDto;
        }


        public void PerformAs<T>(T actor) where T : Actor
        {
            //actor.AttemptsTo(Post.DataAsJson(_ownerRegisterDto).To("account/register"));
            //var result = actor.AsksFor(LastResponse.Content<Result<UserJwtTokenDto>>());
            //actor.Remember(MagicKey.Owner.Regiser_Result, result);
        }
    }
}

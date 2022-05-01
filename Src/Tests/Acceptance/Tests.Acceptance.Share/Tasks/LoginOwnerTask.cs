using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using TaskoMask.Tests.Acceptance.Share.Helpers;
using TaskoMask.Tests.Acceptance.Share.Models;

namespace TaskoMask.Tests.Acceptance.Share.Tasks
{
    public class LoginOwnerTask : ITask
    {
        private readonly OwnerLoginDto _ownerLoginDto;

        public LoginOwnerTask(OwnerLoginDto ownerLoginDto)
        {
            _ownerLoginDto = ownerLoginDto;
        }


        public void PerformAs<T>(T actor) where T : Actor
        {
            //actor.AttemptsTo(Post.DataAsJson(_ownerLoginDto).To("account/login"));
            //var result = actor.AsksFor(LastResponse.Content<Result<UserJwtTokenDto>>());
           // actor.Remember(MagicKey.Owner.Login_Result, result);
        }
    }
}

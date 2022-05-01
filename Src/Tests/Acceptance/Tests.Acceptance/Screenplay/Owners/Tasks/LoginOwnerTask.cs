using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Share.Helpers;
using TaskoMask.Tests.Acceptance.Models.Owners;

namespace TaskoMask.Tests.Acceptance.Screenplay.Owners.Tasks
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
            actor.AttemptsTo(Post.DataAsJson(_ownerLoginDto).To("account/login"));
            var result = actor.AsksFor(LastResponse.Content<Result<UserJwtTokenDto>>());
            actor.Remember(MagicKey.Owner.Login_Result, result);
        }
    }
}

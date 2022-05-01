using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Share.Helpers;
using TaskoMask.Tests.Acceptance.Share.Models;
using TaskoMask.Tests.Acceptance.Share.Tasks;

namespace TaskoMask.Tests.Acceptance.API.Tasks
{
    public class LoginOwnerAPITask : LoginOwnerTask
    {
        public LoginOwnerAPITask(OwnerLoginDto ownerLoginDto) : base(ownerLoginDto)
        {

        }


        protected override bool DoLogin<T>(T actor)
        {
            actor.AttemptsTo(Post.DataAsJson(OwnerLoginDto).To("account/login"));
            var result = actor.AsksFor(LastResponse.Content<Result<UserJwtTokenDto>>());
            return result.IsSuccess;
        }


    }
}

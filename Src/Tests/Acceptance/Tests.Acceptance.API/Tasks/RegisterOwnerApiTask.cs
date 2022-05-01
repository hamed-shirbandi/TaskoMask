using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Share.Helpers;
using TaskoMask.Tests.Acceptance.Share.Models;
using TaskoMask.Tests.Acceptance.Share.Tasks;

namespace TaskoMask.Tests.Acceptance.API.Tasks
{
    public class RegisterOwnerApiTask : RegisterOwnerTask
    {
        public RegisterOwnerApiTask(OwnerRegisterDto ownerRegisterDto) : base(ownerRegisterDto)
        {

        }


        protected override bool DoRegister<T>(T actor)
        {
            actor.AttemptsTo(Post.DataAsJson(OwnerRegisterDto).To("account/register"));
            var result = actor.AsksFor(LastResponse.Content<Result<UserJwtTokenDto>>());
            return result.IsSuccess;
        }

    }
}

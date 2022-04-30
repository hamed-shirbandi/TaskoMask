using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;
using TaskoMask.Tests.Acceptance.Models;

namespace TaskoMask.Tests.Acceptance.Screenplay.Owners
{
    public class RegisterOwner : ITask
    {
        private readonly OwnerRegisterDto _ownerRegisterDto;

        public RegisterOwner(OwnerRegisterDto ownerRegisterDto)
        {
            _ownerRegisterDto = ownerRegisterDto;
        }


        public void PerformAs<T>(T actor) where T : Actor
        {
            actor.AttemptsTo(Post.DataAsJson(_ownerRegisterDto).To("account/login"));
        }
    }
}

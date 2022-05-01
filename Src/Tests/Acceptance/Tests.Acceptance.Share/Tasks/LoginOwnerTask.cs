using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using TaskoMask.Tests.Acceptance.Share.Helpers;
using TaskoMask.Tests.Acceptance.Share.Models;

namespace TaskoMask.Tests.Acceptance.Share.Tasks
{
    public abstract class LoginOwnerTask : ITask
    {
        protected readonly OwnerLoginDto OwnerLoginDto;

        public LoginOwnerTask(OwnerLoginDto ownerLoginDto)
        {
            OwnerLoginDto = ownerLoginDto;
        }


        public void PerformAs<T>(T actor) where T : Actor
        {
            var result = DoLogin(actor);

            actor.Remember(MagicKey.Owner.Login_Result, result);
        }


        protected abstract bool DoLogin<T>(T actor) where T : Actor;
    }
}

using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using TaskoMask.Tests.Acceptance.Core.Helpers;
using TaskoMask.Tests.Acceptance.Core.Models;

namespace TaskoMask.Tests.Acceptance.Core.Screenplay.Tasks;

public abstract class RegisterOwnerTask : ITask
{
    protected readonly OwnerRegisterDto OwnerRegisterDto;

    public RegisterOwnerTask(OwnerRegisterDto ownerRegisterDto)
    {
        OwnerRegisterDto = ownerRegisterDto;
    }

    public void PerformAs<T>(T actor)
        where T : Actor
    {
        var result = DoRegister(actor);

        actor.Remember(MagicKey.Owner.REGISER_RESULT, result);
    }

    protected abstract bool DoRegister<T>(T actor)
        where T : Actor;
}

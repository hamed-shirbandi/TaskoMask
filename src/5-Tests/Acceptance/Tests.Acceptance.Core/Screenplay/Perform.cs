using Suzianna.Core.Screenplay;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Tasks;

namespace TaskoMask.Tests.Acceptance.Core.Screenplay;

/// <summary>
/// Perform holds all Tasks
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
}

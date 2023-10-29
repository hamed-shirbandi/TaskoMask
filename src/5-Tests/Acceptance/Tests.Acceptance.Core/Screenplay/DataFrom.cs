using Suzianna.Core.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Core.Helpers;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Questions;

namespace TaskoMask.Tests.Acceptance.Core.Screenplay;

/// <summary>
/// Perform holds all Questions
/// It is used just to bring out technical decisions from spec definitions
/// So it helps us to chose between API or UI level to run the tests without modifing the spec definition class
/// </summary>
public static class DataFrom
{
    /// <summary>
    ///
    /// </summary>
    public static IQuestion<Result<OwnerBasicInfoDto>> LastOwner()
    {
        return Factory.CreateQuestion<LastOwnerQuestion>();
    }
}

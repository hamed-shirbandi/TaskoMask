using Microsoft.AspNetCore.Identity;

namespace TaskoMask.Services.Identity.Tests.Unit.Helpers;

public class TestIdentityResult : IdentityResult
{
    public TestIdentityResult(bool succeeded = false)
    {
        Succeeded = succeeded;
    }
}

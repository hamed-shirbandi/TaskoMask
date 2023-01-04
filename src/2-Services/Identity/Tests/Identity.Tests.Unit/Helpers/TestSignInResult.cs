using Microsoft.AspNetCore.Identity;

namespace TaskoMask.Services.Identity.Tests.Unit.Helpers
{
    public class TestSignInResult : SignInResult
    {
        public TestSignInResult(bool succeeded = false)
        {
            Succeeded = succeeded;
        }
    }
}

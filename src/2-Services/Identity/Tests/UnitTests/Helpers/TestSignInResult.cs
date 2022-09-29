using Microsoft.AspNetCore.Identity;

namespace TaskoMask.Services.Identity.UnitTests.Helpers
{
    public class TestSignInResult : SignInResult
    {
        public TestSignInResult(bool succeeded = false)
        {
            Succeeded = succeeded;
        }
    }
}

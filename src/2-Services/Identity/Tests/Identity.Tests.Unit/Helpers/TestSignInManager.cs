using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Tests.Unit.Helpers
{
    public class TestSignInManager : SignInManager<User>
    {

        public TestSignInManager(TestUserManager userManager) : base(userManager, Substitute.For<IHttpContextAccessor>(), Substitute.For<IUserClaimsPrincipalFactory<User>>(), Substitute.For<IOptions<IdentityOptions>>(), Substitute.For<ILogger<SignInManager<User>>>(), Substitute.For<IAuthenticationSchemeProvider>(), Substitute.For<IUserConfirmation<User>>())
        {
        }
    }
}

using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;

namespace TaskoMask.Presentation.Framework.Web.Services.Authentication.JwtAuthentication
{
    public interface IJwtAuthenticationService: IAuthenticatedUserService
    {
        string GenerateJwtToken(AuthenticatedUser user);
    }
}

using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;

namespace TaskoMask.Web.Common.Services.Authentication.JwtAuthentication
{
    public interface IJwtAuthenticationService: IAuthenticatedUserService
    {
        string GenerateJwtToken(AuthenticatedUser user);
    }
}

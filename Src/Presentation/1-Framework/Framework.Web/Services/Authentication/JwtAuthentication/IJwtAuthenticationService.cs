using TaskoMask.Domain.Share.Models;

namespace TaskoMask.Presentation.Framework.Web.Services.Authentication.JwtAuthentication
{
    public interface IJwtAuthenticationService
    {
        string GenerateJwtToken(AuthenticatedUser user);
    }
}

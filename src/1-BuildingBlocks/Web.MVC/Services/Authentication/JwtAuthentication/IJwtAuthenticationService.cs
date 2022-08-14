using TaskoMask.Services.Monolith.Domain.Share.Models;

namespace TaskoMask.Services.Monolith.Presentation.Framework.Web.Services.Authentication.JwtAuthentication
{
    public interface IJwtAuthenticationService
    {
        string GenerateJwtToken(AuthenticatedUser user);
    }
}

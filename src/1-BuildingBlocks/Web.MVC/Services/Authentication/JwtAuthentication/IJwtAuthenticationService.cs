using TaskoMask.Services.Monolith.Domain.Share.Models;

namespace TaskoMask.BuildingBlocks.Web.MVC.Services.Authentication.JwtAuthentication
{
    public interface IJwtAuthenticationService
    {
        string GenerateJwtToken(AuthenticatedUser user);
    }
}

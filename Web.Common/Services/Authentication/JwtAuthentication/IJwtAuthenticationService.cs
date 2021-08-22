using TaskoMask.Web.Common.Services.Authentication.Models;

namespace TaskoMask.Web.Common.Services.Authentication.JwtAuthentication
{
    public interface IJwtAuthenticationService
    {
        string GenerateJwtToken<T>(string userName, string id, T user);
    }
}

using TaskoMask.Services.Monolith.Domain.Share.Models;

namespace TaskoMask.Services.Monolith.Presentation.Framework.Web.Services.Authentication.CookieAuthentication
{
    public interface ICookieAuthenticationService
    {
        Task SignInAsync(AuthenticatedUser user, bool isPersistent);
        Task SignOutAsync();
    }
}
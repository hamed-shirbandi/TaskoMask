using TaskoMask.Domain.Share.Models;

namespace TaskoMask.Presentation.Framework.Share.Services.Authentication.CookieAuthentication
{
    public interface ICookieAuthenticationService
    {
        Task SignInAsync(AuthenticatedUser user, bool isPersistent);
        Task SignOutAsync();
    }
}
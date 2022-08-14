using TaskoMask.Services.Monolith.Domain.Share.Models;

namespace TaskoMask.BuildingBlocks.Web.MVC.Services.Authentication.CookieAuthentication
{
    public interface ICookieAuthenticationService
    {
        Task SignInAsync(AuthenticatedUser user, bool isPersistent);
        Task SignOutAsync();
    }
}
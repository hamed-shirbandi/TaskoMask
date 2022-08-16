using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Web.MVC.Services.Authentication.CookieAuthentication
{
    public interface ICookieAuthenticationService
    {
        Task SignInAsync(AuthenticatedUserModel user, bool isPersistent);
        Task SignOutAsync();
    }
}
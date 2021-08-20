using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Web.Common.Services.Authentication.Models;

namespace TaskoMask.Web.Common.Services.Authentication.CookieAuthentication
{
    public interface ICookieAuthenticationService
    {
        Task SignInAsync(UserBasicInfoDto user, bool isPersistent);
        Task SignOutAsync();
        bool IsAuthenticated();
        AuthenticatedUserModel GetAuthenticatedUser();

        //TODO adding tow factore and external login
    }
}
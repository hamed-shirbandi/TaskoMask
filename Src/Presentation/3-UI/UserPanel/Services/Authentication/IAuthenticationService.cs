using TaskoMask.Presentation.Framework.Share.ApiContracts;

namespace TaskoMask.Presentation.UI.UserPanel.Services.Authentication
{
    public interface IAuthenticationService : IAccountApiService
    {
       Task Logout();
    }
}
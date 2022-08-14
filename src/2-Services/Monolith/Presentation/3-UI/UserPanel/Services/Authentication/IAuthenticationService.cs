using TaskoMask.Services.Monolith.Presentation.Framework.Share.ApiContracts;

namespace TaskoMask.Services.Monolith.Presentation.UI.UserPanel.Services.Authentication
{
    public interface IAuthenticationService : IAccountApiService
    {
       Task Logout();
    }
}
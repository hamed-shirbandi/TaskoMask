
using TaskoMask.Presentation.Framework.Share.Contracts;

namespace TaskoMask.Presentation.UI.UserPanel.Services.Authentication
{
    public interface IAuthenticationService : IAccountClientService
    {
       void Logout();
    }
}
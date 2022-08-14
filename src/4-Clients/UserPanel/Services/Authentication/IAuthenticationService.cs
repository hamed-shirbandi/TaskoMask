using TaskoMask.BuildingBlocks.Web.ApiContracts;

namespace TaskoMask.Clients.UserPanel.Services.Authentication
{
    public interface IAuthenticationService : IAccountApiService
    {
       Task Logout();
    }
}
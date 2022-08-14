using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Domain.Services
{
    public interface IAuthenticatedUserService
    {
        bool IsAuthenticated();
        string GetUserId();
        string GetUserName();
        AuthenticatedUser GetAuthenticatedUser();
    }
}

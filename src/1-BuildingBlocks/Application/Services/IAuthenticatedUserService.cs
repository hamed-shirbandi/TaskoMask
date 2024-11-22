using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Application.Services;

public interface IAuthenticatedUserService
{
    bool IsAuthenticated();
    string GetUserId();
    string GetUserName();
    AuthenticatedUserModel GetAuthenticatedUser();
}

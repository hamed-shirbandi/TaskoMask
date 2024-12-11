using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Application.Services;

public interface ICurrentUser
{
    bool IsAuthenticated();
    string GetUserId();
    string GetUserName();
}

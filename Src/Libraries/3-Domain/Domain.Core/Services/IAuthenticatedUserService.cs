using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Core.Services
{
    public interface IAuthenticatedUserService
    {
        bool IsAuthenticated();
        string GetUserId();
        string GetUserName();
        AuthenticatedUser GetAuthenticatedUser();
    }
}

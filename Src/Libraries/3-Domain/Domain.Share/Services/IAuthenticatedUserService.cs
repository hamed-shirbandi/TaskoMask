using TaskoMask.Domain.Share.Models;

namespace TaskoMask.Domain.Share.Services
{
    public interface IAuthenticatedUserService
    {
        bool IsAuthenticated();
        string GetUserId();
        string GetUserName();
        AuthenticatedUser GetAuthenticatedUser();
    }
}

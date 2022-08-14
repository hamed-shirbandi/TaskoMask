using TaskoMask.Services.Monolith.Domain.Share.Models;

namespace TaskoMask.Services.Monolith.Domain.Core.Services
{
    public interface IAuthenticatedUserService
    {
        bool IsAuthenticated();
        string GetUserId();
        string GetUserName();
        AuthenticatedUser GetAuthenticatedUser();
    }
}

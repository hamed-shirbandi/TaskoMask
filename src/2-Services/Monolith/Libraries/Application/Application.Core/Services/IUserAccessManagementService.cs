using System.Threading.Tasks;

namespace TaskoMask.Services.Monolith.Application.Core.Services
{
    public interface IUserAccessManagementService
    {
        Task<bool> CanAccessToBoardAsync(string boardId);
        Task<bool> CanAccessToCardAsync(string cardId);
        Task<bool> CanAccessToTaskAsync(string taskId);
    }
}

using System.Threading.Tasks;

namespace TaskoMask.Services.Monolith.Application.Core.Services
{
    public interface IUserAccessManagementService
    {
        Task<bool> CanAccessToOrganizationAsync(string organizationId);
        Task<bool> CanAccessToProjectAsync(string projectId);
        Task<bool> CanAccessToBoardAsync(string boardId);
        Task<bool> CanAccessToCardAsync(string cardId);
        Task<bool> CanAccessToTaskAsync(string taskId);
    }
}

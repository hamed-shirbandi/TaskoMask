using System.Threading.Tasks;

namespace TaskoMask.Services.Monolith.Application.Core.Services
{
    public interface IUserAccessManagementService
    {
        Task<bool> CanAccessToTaskAsync(string taskId);
    }
}

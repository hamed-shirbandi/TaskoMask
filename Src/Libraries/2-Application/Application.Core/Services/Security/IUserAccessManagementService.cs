using System.Threading.Tasks;

namespace TaskoMask.Application.Core.Services
{
    public interface IUserAccessManagementService
    {
        Task<bool> CanAccessToOrganizationAsync(string organizationId);
        Task<bool> CanAccessToProjectAsync(string projectId);
    }
}

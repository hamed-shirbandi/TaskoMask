using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Core.Services.Application;

namespace TaskoMask.Application.Workspace.Owners.Services
{
    public interface IOwnerService : IApplicationService
    {
        Task<Result<CommandResult>> RegisterAsync(RegisterOwnerDto input);
        Task<Result<CommandResult>> RegisterAndSeedDefaultWorkspaceAsync(RegisterOwnerDto input);
        Task<Result<CommandResult>> UpdateProfileAsync(UpdateOwnerProfileDto input);
        Task<Result<OwnerBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<OwnerBasicInfoDto>> GetByUserNameAsync(string userName);
        Task<Result<PaginatedListReturnType<OwnerOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<OwnerDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<long>> CountAsync();
    }
}

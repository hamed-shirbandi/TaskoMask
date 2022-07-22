using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Core.Services;

namespace TaskoMask.Application.Workspace.Owners.Services
{
    public interface IOwnerService : IApplicationService
    {
        Task<Result<CommandResult>> CreateAsync(OwnerRegisterDto input);
        Task<Result<CommandResult>> CreateWithDefaultWorkspaceAsync(OwnerRegisterDto input);

        Task<Result<CommandResult>> UpdateAsync(OwnerUpdateDto input);
        Task<Result<OwnerBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<OwnerBasicInfoDto>> GetByUserNameAsync(string userName);
        Task<Result<PaginatedListReturnType<OwnerOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<OwnerDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<long>> CountAsync();
        Task CreateDefaultWorkspaceAsync(string ownerId);
    }
}

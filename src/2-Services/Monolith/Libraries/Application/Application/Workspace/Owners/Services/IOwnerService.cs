using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.Services.Monolith.Application.Workspace.Owners.Services
{
    public interface IOwnerService : IApplicationService
    {
        Task<Result<CommandResult>> RegisterAsync(RegisterOwnerDto input);
        Task<Result<CommandResult>> RegisterAndSeedDefaultWorkspaceAsync(RegisterOwnerDto input);
        Task<Result<CommandResult>> UpdateProfileAsync(UpdateOwnerProfileDto input);
        Task<Result<OwnerBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<OwnerBasicInfoDto>> GetByEmailAsync(string userName);
        Task<Result<PaginatedList<OwnerOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<OwnerDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<long>> CountAsync();
    }
}

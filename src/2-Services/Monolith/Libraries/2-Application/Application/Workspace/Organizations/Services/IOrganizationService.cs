using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Organizations;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.Services.Monolith.Application.Core.Services.Application;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Organizations.Services
{
    public interface IOrganizationService : IApplicationService
    {
        Task<Result<CommandResult>> AddAsync(AddOrganizationDto input);
        Task<Result<CommandResult>> UpdateAsync(UpdateOrganizationDto input);
        Task<Result<OrganizationDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<IEnumerable<OrganizationDetailsViewModel>>> GetListWithDetailsByOwnerIdAsync(string ownerId);
        Task<Result<OrganizationBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<IEnumerable<OrganizationBasicInfoDto>>> GetListByOwnerIdAsync(string ownerId);
        Task<Result<PaginatedList<OrganizationOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<IEnumerable<SelectListItem>>> GetSelectListAsync(string ownerId);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> DeleteAsync(string id);
    }
}

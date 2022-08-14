using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Projects;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.Services.Monolith.Application.Core.Services.Application;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.Services
{
    public interface IProjectService : IApplicationService
    {
        Task<Result<CommandResult>> AddAsync(AddProjectDto input);
        Task<Result<CommandResult>> UpdateAsync(UpdateProjectDto input);
        Task<Result<ProjectOutputDto>> GetByIdAsync(string id);
        Task<Result<ProjectDetailsViewModel>> GetDetailsAsync(string id);

        Task<Result<IEnumerable<ProjectBasicInfoDto>>> GetListByOrganizationIdAsync(string organizationId);
        Task<Result<PaginatedList<ProjectOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<IEnumerable<SelectListItem>>> GetSelectListAsync(string organizationId);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> DeleteAsync(string id);
    }
}

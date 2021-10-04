using TaskoMask.Application.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Common.BaseEntities.Services;

namespace TaskoMask.Application.Team.Projects.Services
{
    public interface IProjectService : IBaseEntityService
    {
        Task<Result<CommandResult>> CreateAsync(ProjectInputDto input);
        Task<Result<CommandResult>> UpdateAsync(ProjectInputDto input);
        Task<Result<ProjectDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<ProjectBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<ProjectReportDto>> GetReportAsync(string id);
        Task<Result<IEnumerable<ProjectBasicInfoDto>>> GetListByOrganizationIdAsync(string organizationId);
    }
}

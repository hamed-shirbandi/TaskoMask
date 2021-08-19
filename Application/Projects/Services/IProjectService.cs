using TaskoMask.Domain.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;

namespace TaskoMask.Application.Projects.Services
{
    public interface IProjectService : IBaseEntityService
    {
        Task<Result<CommandResult>> CreateAsync(ProjectInputDto input);
        Task<Result<CommandResult>> UpdateAsync(ProjectInputDto input);
        Task<Result<ProjectDetailViewModel>> GetDetailAsync(string id);
        Task<Result<ProjectBasicInfoDto>> GetAsync(string id);
        Task<Result<ProjectReportDto>> GetReportAsync(string id);
        Task<Result<IEnumerable<ProjectBasicInfoDto>>> GetListByOrganizationIdAsync(string organizationId);
    }
}

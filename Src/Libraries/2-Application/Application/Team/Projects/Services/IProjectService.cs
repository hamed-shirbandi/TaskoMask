using TaskoMask.Application.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Team.Projects;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Common.Base.Services;
using TaskoMask.Application.Core.Dtos.Team.Organizations;

namespace TaskoMask.Application.Team.Projects.Services
{
    public interface IProjectService : IBaseService
    {
        Task<Result<CommandResult>> CreateAsync(ProjectUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(ProjectUpsertDto input);
        Task<Result<ProjectDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<ProjectBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<ProjectReportDto>> GetReportAsync(string id);
        Task<Result<IEnumerable<ProjectBasicInfoDto>>> GetListByOrganizationIdAsync(string organizationId);
        Task<Result<PublicPaginatedListReturnType<ProjectOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
    }
}

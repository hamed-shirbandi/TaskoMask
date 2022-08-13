﻿using TaskoMask.Application.Share.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Core.Services.Application;

namespace TaskoMask.Application.Workspace.Projects.Services
{
    public interface IProjectService : IApplicationService
    {
        Task<Result<CommandResult>> AddAsync(AddProjectDto input);
        Task<Result<CommandResult>> UpdateAsync(UpdateProjectDto input);
        Task<Result<ProjectOutputDto>> GetByIdAsync(string id);
        Task<Result<ProjectDetailsViewModel>> GetDetailsAsync(string id);

        Task<Result<IEnumerable<ProjectBasicInfoDto>>> GetListByOrganizationIdAsync(string organizationId);
        Task<Result<PaginatedListReturnType<ProjectOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<IEnumerable<SelectListItem>>> GetSelectListAsync(string organizationId);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> DeleteAsync(string id);
    }
}

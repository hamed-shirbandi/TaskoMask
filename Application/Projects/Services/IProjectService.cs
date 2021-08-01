using TaskoMask.Application.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;

namespace TaskoMask.Application.Projects.Services
{
    public interface IProjectService : IBaseEntityService
    {
        #region Command Services

        Task<Result<CommandResult>> CreateAsync(ProjectInputDto input);
        Task<Result<CommandResult>> UpdateAsync(ProjectInputDto input);

        #endregion

        #region Query Services

        Task<ProjectOutputDto> GetByIdAsync(string id);
        Task<ProjectInputDto> GetByIdToUpdateAsync(string id);
        Task<ProjectDetailViewModel> GetListByOrganizationIdAsync(string organizationId);

        #endregion

    }
}

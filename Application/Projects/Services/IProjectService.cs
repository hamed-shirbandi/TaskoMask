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

        Task<Result<CommandResult>> CreateAsync(ProjectInput input);
        Task<Result<CommandResult>> UpdateAsync(ProjectInput input);

        #endregion

        #region Query Services

        Task<ProjectOutput> GetByIdAsync(string id);
        Task<ProjectInput> GetByIdToUpdateAsync(string id);
        Task<ProjectListViewModel> GetListByOrganizationIdAsync(string organizationId);

        #endregion

    }
}

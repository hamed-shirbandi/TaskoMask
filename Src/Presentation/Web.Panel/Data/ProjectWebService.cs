using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Team.Projects;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Web.Common.Contracts;

namespace TaskoMask.Web.Panel.Data
{
    public class ProjectWebService : IProjectWebService
    {
        public Task<Result<CommandResult>> Create(ProjectUpsertDto input)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ProjectDetailsViewModel>> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommandResult>> Update(ProjectUpsertDto input)
        {
            throw new NotImplementedException();
        }
    }
}

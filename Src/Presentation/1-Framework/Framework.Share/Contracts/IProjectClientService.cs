using TaskoMask.Application.Share.Dtos.Team.Projects;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public interface IProjectClientService
    {
        Task<Result<CommandResult>> Create(ProjectUpsertDto input);
        Task<Result<ProjectDetailsViewModel>> Get(string id);
        Task<Result<CommandResult>> Update(ProjectUpsertDto input);
    }
}

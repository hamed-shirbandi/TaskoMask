using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public interface IProjectClientService
    {
        Task<Result<ProjectOutputDto>> Get(string id);
        Task<Result<ProjectDetailsViewModel>> GetDetails(string id);

        Task<Result<CommandResult>> Create(ProjectCreateDto input);
        Task<Result<CommandResult>> Update(string id, ProjectUpdateDto input);
        Task<Result<CommandResult>> Delete(string id);
        Task<Result<IEnumerable<SelectListItem>>> GetSelectListItems(string organizationId);

    }
}

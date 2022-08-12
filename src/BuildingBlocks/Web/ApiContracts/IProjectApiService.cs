using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.Framework.Share.ApiContracts
{
    public interface IProjectApiService
    {
        Task<Result<ProjectOutputDto>> Get(string id);
        Task<Result<ProjectDetailsViewModel>> GetDetails(string id);
        Task<Result<CommandResult>> Add(AddProjectDto input);
        Task<Result<CommandResult>> Update(string id, UpdateProjectDto input);
        Task<Result<CommandResult>> Delete(string id);
        Task<Result<IEnumerable<SelectListItem>>> GetSelectListItems(string organizationId);

    }
}

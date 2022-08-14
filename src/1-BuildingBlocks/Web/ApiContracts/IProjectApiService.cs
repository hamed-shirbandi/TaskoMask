using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Application.Share.ViewModels;

namespace TaskoMask.Services.Monolith.Presentation.Framework.Share.ApiContracts
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

using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts
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

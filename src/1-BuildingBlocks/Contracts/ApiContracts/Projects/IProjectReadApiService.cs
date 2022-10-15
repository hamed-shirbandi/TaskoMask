using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts.Projects
{
    public interface IProjectReadApiService
    {
        Task<Result<ProjectOutputDto>> Get(string id);
        Task<Result<ProjectDetailsViewModel>> GetDetails(string id);
        Task<Result<IEnumerable<SelectListItem>>> GetSelectListItems(string organizationId);

    }
}

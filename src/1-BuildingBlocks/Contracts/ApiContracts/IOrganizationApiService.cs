using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts
{
    public interface IOrganizationApiService
    {
        Task<Result<OrganizationBasicInfoDto>> Get(string id);
        Task<Result<IEnumerable<OrganizationDetailsViewModel>>> Get();
        Task<Result<IEnumerable<SelectListItem>>> GetSelectListItems();
        Task<Result<CommandResult>> Add(AddOrganizationDto input);
        Task<Result<CommandResult>> Update(string id, UpdateOrganizationDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}

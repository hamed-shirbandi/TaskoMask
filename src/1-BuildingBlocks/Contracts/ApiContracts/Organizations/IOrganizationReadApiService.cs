using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts.Organizations
{
    public interface IOrganizationReadApiService
    {
        Task<Result<OrganizationBasicInfoDto>> Get(string id);
        Task<Result<IEnumerable<OrganizationDetailsViewModel>>> Get();
        Task<Result<IEnumerable<SelectListItem>>> GetSelectListItems();
    }
}

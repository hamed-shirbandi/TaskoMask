using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Application.Share.ViewModels;

namespace TaskoMask.Services.Monolith.Presentation.Framework.Share.ApiContracts
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

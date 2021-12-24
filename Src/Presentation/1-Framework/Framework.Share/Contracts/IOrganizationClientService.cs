using TaskoMask.Application.Share.Dtos.Team.Organizations;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public interface IOrganizationClientService
    {
        Task<Result<OrganizationBasicInfoDto>> Get(string id);
        Task<Result<IEnumerable<OrganizationDetailsViewModel>>> Get();
        Task<Result<CommandResult>> Create(OrganizationUpsertDto input);
        Task<Result<CommandResult>> Update(OrganizationUpsertDto input);
    }
}

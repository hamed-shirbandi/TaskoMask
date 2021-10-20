using TaskoMask.Application.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Common.BaseEntities.Services;

namespace TaskoMask.Application.Team.Organizations.Services
{
    public interface IOrganizationService : IBaseEntityService
    {
        Task<Result<CommandResult>> CreateAsync(OrganizationInputDto input);
        Task<Result<CommandResult>> UpdateAsync(OrganizationInputDto input);
        Task<Result<OrganizationDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<IEnumerable<OrganizationDetailsViewModel>>> GetListWithDetailsByOwnerMemberIdAsync(string ownerMemberId);
        Task<Result<OrganizationBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<OrganizationReportDto>> GetReportAsync(string id);
        Task<Result<IEnumerable<OrganizationBasicInfoDto>>> GetListByOwnerMemberIdAsync(string ownerMemberId);
    }
}

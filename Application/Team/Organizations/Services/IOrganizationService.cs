using TaskoMask.Application.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Common.Base.Services;

namespace TaskoMask.Application.Team.Organizations.Services
{
    public interface IOrganizationService : IBaseService
    {
        Task<Result<CommandResult>> CreateAsync(OrganizationUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(OrganizationUpsertDto input);
        Task<Result<OrganizationDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<IEnumerable<OrganizationDetailsViewModel>>> GetListWithDetailsByOwnerMemberIdAsync(string ownerMemberId);
        Task<Result<OrganizationBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<OrganizationReportDto>> GetReportAsync(string id);
        Task<Result<IEnumerable<OrganizationBasicInfoDto>>> GetListByOwnerMemberIdAsync(string ownerMemberId);
    }
}

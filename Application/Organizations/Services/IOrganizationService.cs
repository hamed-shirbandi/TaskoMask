using TaskoMask.Domain.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Base.Services;

namespace TaskoMask.Application.Organizations.Services
{
    public interface IOrganizationService : IBaseService
    {
        Task<Result<CommandResult>> CreateAsync(OrganizationInputDto input);
        Task<Result<CommandResult>> UpdateAsync(OrganizationInputDto input);
        Task<Result<OrganizationDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<IEnumerable<OrganizationDetailsViewModel>>> GetUserOrganizationsDetailAsync(string userId);
        Task<Result<OrganizationBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<OrganizationReportDto>> GetReportAsync(string id);
        Task<Result<IEnumerable<OrganizationBasicInfoDto>>> GetListByUserIdAsync(string userId);
    }
}

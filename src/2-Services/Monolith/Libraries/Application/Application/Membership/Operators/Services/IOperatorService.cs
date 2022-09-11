using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Operators;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.Services.Monolith.Application.Membership.Operators.Services
{
    public interface IOperatorService: IApplicationService
    {
        Task<Result<CommandResult>> CreateAsync(OperatorUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(OperatorUpsertDto input);
        Task<Result<OperatorBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<OperatorBasicInfoDto>> GetByEmailAsync(string userName);
        Task<Result<IEnumerable<OperatorOutputDto>>> GetListAsync();
        Task<Result<OperatorDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<CommandResult>> UpdateRolesAsync(string id, string[] rolesId);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> DeleteAsync(string id);
    }
}

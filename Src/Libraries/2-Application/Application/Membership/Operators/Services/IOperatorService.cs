using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Membership.Operators;
using TaskoMask.Application.Share.ViewModels;
using System.Collections.Generic;
using TaskoMask.Application.Core.Services;

namespace TaskoMask.Application.Membership.Operators.Services
{
    public interface IOperatorService: IApplicationService
    {
        Task<Result<CommandResult>> CreateAsync(OperatorUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(OperatorUpsertDto input);
        Task<Result<OperatorBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<IEnumerable<OperatorOutputDto>>> GetListAsync();
        Task<Result<OperatorDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<CommandResult>> UpdateRolesAsync(string id, string[] rolesId);
    }
}

using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Common.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Common.Users.Services;
using TaskoMask.Application.Core.Dtos.Administration.Operators;
using TaskoMask.Application.Core.ViewModels;
using System.Collections.Generic;

namespace TaskoMask.Application.Administration.Operators.Services
{
    public interface IOperatorService : IUserService
    {
        Task<Result<CommandResult>> CreateAsync(OperatorUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(OperatorUpsertDto input);
        Task<Result<OperatorBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<IEnumerable<OperatorOutputDto>>> GetListAsync();
        Task<Result<OperatorDetailViewModel>> GetDetailsAsync(string id);
        Task<Result<CommandResult>> UpdateRolesAsync(string id, string[] rolesId);
    }
}

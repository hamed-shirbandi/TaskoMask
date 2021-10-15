using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Common.BaseEntitiesUsers.Services;
using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Application.Core.ViewModels;
using System.Collections.Generic;

namespace TaskoMask.Application.Administration.Operators.Services
{
    public interface IOperatorService : IBaseUserService
    {
        Task<Result<CommandResult>> CreateAsync(OperatorInputDto input);
        Task<Result<CommandResult>> UpdateAsync(OperatorInputDto input);
        Task<Result<OperatorBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<IEnumerable<OperatorBasicInfoDto>>> GetListAsync();
        Task<Result<OperatorDetailViewModel>> GetDetailsAsync(string id);
        Task<Result<CommandResult>> UpdateRolesAsync(string id, string[] rolesId);
    }
}

using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Roles;
using TaskoMask.Application.Common.BaseEntities.Services;
using System.Collections.Generic;

namespace TaskoMask.Application.Administration.Roles.Services
{
    public interface IRoleService : IBaseEntityService
    {
        Task<Result<CommandResult>> CreateAsync(RoleInputDto input);
        Task<Result<CommandResult>> UpdateAsync(RoleInputDto input);
        Task<Result<RoleBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<IEnumerable<RoleBasicInfoDto>>> GetListAsync();
    }
}

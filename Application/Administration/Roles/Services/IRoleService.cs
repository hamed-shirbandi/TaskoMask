using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Roles;
using TaskoMask.Application.Common.BaseEntities.Services;
using System.Collections.Generic;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Application.Administration.Roles.Services
{
    public interface IRoleService : IBaseEntityService
    {
        Task<Result<CommandResult>> CreateAsync(RoleInputDto input);
        Task<Result<CommandResult>> UpdateAsync(RoleInputDto input);
        Task<Result<CommandResult>> UpdatePermissionsAsync(string id, string[]permissionsId);
        Task<Result<RoleDetailViewModel>> GetDetailsAsync(string id);
        Task<Result<RoleBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<IEnumerable<RoleOutputDto>>> GetListAsync();
    }
}

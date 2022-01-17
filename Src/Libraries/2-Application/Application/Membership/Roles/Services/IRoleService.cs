using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Share.Dtos.Ownership.Roles;
using TaskoMask.Application.Common.Services;
using System.Collections.Generic;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Application.Ownership.Roles.Services
{
    public interface IRoleService : IBaseService
    {
        Task<Result<CommandResult>> CreateAsync(RoleUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(RoleUpsertDto input);
        Task<Result<CommandResult>> UpdatePermissionsAsync(string id, string[]permissionsId);
        Task<Result<RoleDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<RoleBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<IEnumerable<RoleOutputDto>>> GetListAsync();
    }
}

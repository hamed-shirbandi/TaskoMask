using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Membership.Roles;
using TaskoMask.Application.Core.Services.Application;
using System.Collections.Generic;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Application.Membership.Roles.Services
{
    public interface IRoleService : IApplicationService
    {
        Task<Result<CommandResult>> CreateAsync(RoleUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(RoleUpsertDto input);
        Task<Result<CommandResult>> UpdatePermissionsAsync(string id, string[]permissionsId);
        Task<Result<RoleDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<RoleBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<IEnumerable<RoleOutputDto>>> GetListAsync();
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> DeleteAsync(string id);
    }
}

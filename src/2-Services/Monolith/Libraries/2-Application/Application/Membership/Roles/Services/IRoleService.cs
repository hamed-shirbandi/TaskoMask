using TaskoMask.Services.Monolith.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Membership.Roles;
using TaskoMask.Services.Monolith.Application.Core.Services.Application;
using System.Collections.Generic;
using TaskoMask.Services.Monolith.Application.Share.ViewModels;

namespace TaskoMask.Services.Monolith.Application.Membership.Roles.Services
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

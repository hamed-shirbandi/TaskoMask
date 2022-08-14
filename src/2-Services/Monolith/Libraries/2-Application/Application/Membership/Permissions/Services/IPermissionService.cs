using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Core.Services.Application;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Membership.Permissions;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Application.Share.ViewModels;

namespace TaskoMask.Services.Monolith.Application.Membership.Permissions.Services
{
    public interface IPermissionService : IApplicationService
    {
        Task<Result<CommandResult>> CreateAsync(PermissionUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(PermissionUpsertDto input);
        Task<Result<PermissionBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<PermissionDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<IEnumerable<PermissionBasicInfoDto>>> GetListAsync(string id);
        Task<Result<IEnumerable<PermissionBasicInfoDto>>> GetListByIdsAsync(string[] ids);
        Task<Result<string[]>> GetSystemNameListByOperatorAsync(string userId);
        Task<Result<IEnumerable<PermissionBasicInfoDto>>> GetListByOperatorAsync(string userId);
        Task<Result<SelectListItem[]>> GetGroupedSelectListAsync();
        Task<Result<SelectListItem[]>> GetSelectListAsync(string[] selectedPermissionsId = null);

        Task<Result<PaginatedListReturnType<PermissionOutputDto>>> SearchAsync(int page, int recordsPerPage, string term, string groupName);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> DeleteAsync(string id);

    }
}

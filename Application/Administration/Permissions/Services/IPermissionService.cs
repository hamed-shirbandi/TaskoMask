using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Common.BaseEntities.Services;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Administration.Permissions;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Application.Administration.Permissions.Services
{
    public interface IPermissionService : IBaseEntityService
    {
        Task<Result<CommandResult>> CreateAsync(PermissionUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(PermissionUpsertDto input);

        Task<Result<PermissionBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<PermissionDetailViewModel>> GetDetailsAsync(string id);
        Task<Result<IEnumerable<PermissionBasicInfoDto>>> GetListAsync(string id);
        Task<Result<IEnumerable<PermissionBasicInfoDto>>> GetListByIdsAsync(string[] ids);
        Task<Result<string[]>> GetSystemNameListByOperatorAsync(string userName);
        Task<Result<IEnumerable<PermissionBasicInfoDto>>> GetListByOperatorAsync(string userName);
        Task<Result<SelectListItem[]>> GetGroupedSelectListAsync();
        Task<Result<SelectListItem[]>> GetSelectListAsync(string[] selectedPermissionsId = null);

        Task<Result<PublicPaginatedListReturnType<PermissionOutputDto>>> SearchAsync(int page, int recordsPerPage, string term, string groupName);

    }
}

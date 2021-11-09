using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Administration.Permissions;
using TaskoMask.Application.Core.Dtos.Administration.Roles;

namespace TaskoMask.Application.Core.ViewModels
{
    public class PermissionDetailViewModel
    {
        public PermissionDetailViewModel()
        {
            Permission = new PermissionUpsertDto();
            Roles = new List<RoleBasicInfoDto>();
        }

        public PermissionUpsertDto Permission { get; set; }
        public IEnumerable<RoleBasicInfoDto> Roles { get; set; }
    }
}

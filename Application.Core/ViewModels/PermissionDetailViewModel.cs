using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Permissions;
using TaskoMask.Application.Core.Dtos.Roles;

namespace TaskoMask.Application.Core.ViewModels
{
    public class PermissionDetailViewModel
    {
        public PermissionDetailViewModel()
        {
            Permission = new PermissionBasicInfoDto();
            Roles = new List<RoleBasicInfoDto>();
        }

        public PermissionBasicInfoDto Permission { get; set; }
        public IEnumerable<RoleBasicInfoDto> Roles { get; set; }
    }
}

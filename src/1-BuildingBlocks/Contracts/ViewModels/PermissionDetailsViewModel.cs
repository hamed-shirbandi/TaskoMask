using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Permissions;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Roles;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
    public class PermissionDetailsViewModel
    {
        public PermissionDetailsViewModel()
        {
            Permission = new PermissionUpsertDto();
            Roles = new List<RoleBasicInfoDto>();
        }

        public PermissionUpsertDto Permission { get; set; }
        public IEnumerable<RoleBasicInfoDto> Roles { get; set; }
    }
}

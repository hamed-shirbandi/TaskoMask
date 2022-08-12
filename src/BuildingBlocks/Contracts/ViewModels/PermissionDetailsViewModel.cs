﻿using TaskoMask.Application.Share.Dtos.Membership.Permissions;
using TaskoMask.Application.Share.Dtos.Membership.Roles;

namespace TaskoMask.Application.Share.ViewModels
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

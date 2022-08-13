using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Membership.Permissions
{
    public class PermissionOutputDto : PermissionBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.RolesCount), ResourceType = typeof(ApplicationMetadata))]
        public long RolesCount { get; set; }
    }
}

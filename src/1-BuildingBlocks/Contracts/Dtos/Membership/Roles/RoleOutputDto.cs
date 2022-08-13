using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Membership.Roles
{
    public class RoleOutputDto : RoleBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.OperatorsCount), ResourceType = typeof(ApplicationMetadata))]
        public long OperatorsCount { get; set; }
        
        [Display(Name = nameof(ApplicationMetadata.PermissionsCount), ResourceType = typeof(ApplicationMetadata))]
        public long PermissionsCount { get; set; }
        
    }
}

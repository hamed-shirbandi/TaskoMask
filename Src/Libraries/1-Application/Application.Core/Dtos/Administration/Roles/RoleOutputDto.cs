using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Administration.Roles
{
    public class RoleOutputDto : RoleBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.OperatorsCount), ResourceType = typeof(ApplicationMetadata))]
        public long OperatorsCount { get; set; }
        [Display(Name = nameof(ApplicationMetadata.PermissionsCount), ResourceType = typeof(ApplicationMetadata))]
        public long PermissionsCount { get; set; }
        
    }
}

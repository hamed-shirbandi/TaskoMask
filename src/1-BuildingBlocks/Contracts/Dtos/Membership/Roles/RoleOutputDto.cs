using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Roles
{
    public class RoleOutputDto : RoleBasicInfoDto
    {
        [Display(Name = nameof(ContractsMetadata.OperatorsCount), ResourceType = typeof(ContractsMetadata))]
        public long OperatorsCount { get; set; }
        
        [Display(Name = nameof(ContractsMetadata.PermissionsCount), ResourceType = typeof(ContractsMetadata))]
        public long PermissionsCount { get; set; }
        
    }
}



using TaskoMask.BuildingBlocks.Contracts.Resources;
using System.ComponentModel.DataAnnotations;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Permissions
{
    public class PermissionBasicInfoDto
    {

        public string Id { get; set; }

        [Display(Name = nameof(ContractsMetadata.Name), ResourceType = typeof(ContractsMetadata))]
        public string DisplayName { get; set; }


        [Display(Name = nameof(ContractsMetadata.Permission_SystemName), ResourceType = typeof(ContractsMetadata))]
        public string SystemName { get; set; }


        [Display(Name = nameof(ContractsMetadata.Permission_GroupName), ResourceType = typeof(ContractsMetadata))]
        public string GroupName { get; set; }
    }
}

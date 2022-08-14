using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Operators
{
    public class OperatorOutputDto : OperatorBasicInfoDto
    {
        [Display(Name = nameof(ContractsMetadata.RolesCount), ResourceType = typeof(ContractsMetadata))]
        public long RolesCount { get; set; }
        
    }
}

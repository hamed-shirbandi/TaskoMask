using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations
{
    public class OrganizationOutputDto : OrganizationBasicInfoDto
    {
        [Display(Name = nameof(ContractsMetadata.ProjectsCount), ResourceType = typeof(ContractsMetadata))]
        public long ProjectsCount { get; set; }
        [Display(Name = nameof(ContractsMetadata.OwnerDisplayName), ResourceType = typeof(ContractsMetadata))]
        public string OwnerOwnerDisplayName { get; set; }
    }
}

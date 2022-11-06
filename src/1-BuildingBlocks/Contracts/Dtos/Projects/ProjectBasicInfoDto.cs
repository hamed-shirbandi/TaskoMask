using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Projects
{
    public class ProjectBasicInfoDto: ProjectBaseDto
    {
        [Display(Name = nameof(ContractsMetadata.OrganizationName), ResourceType = typeof(ContractsMetadata))]
        public string OrganizationName { get; set; }

        public CreationTimeDto CreationTime { get; set; }
    }
}

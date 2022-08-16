using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Projects
{
   public class ProjectOutputDto: ProjectBasicInfoDto
    {
        [Display(Name = nameof(ContractsMetadata.OrganizationName), ResourceType = typeof(ContractsMetadata))]
        public string OrganizationName { get; set; }

        [Display(Name = nameof(ContractsMetadata.BoardsCount), ResourceType = typeof(ContractsMetadata))]
        public long BoardsCount { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Boards
{
    public class BoardOutputDto : BoardBasicInfoDto
    {
        [Display(Name = nameof(ContractsMetadata.ProjectName), ResourceType = typeof(ContractsMetadata))]
        public string ProjectName { get; set; }

        [Display(Name = nameof(ContractsMetadata.OrganizationName), ResourceType = typeof(ContractsMetadata))]
        public string OrganizationName { get; set; }


    }
}

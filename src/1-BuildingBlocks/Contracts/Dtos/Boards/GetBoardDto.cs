using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;

public class GetBoardDto : BoardBaseDto
{
    public string OwnerId { get; set; }

    public string OrganizationId { get; set; }

    [Display(Name = nameof(ContractsMetadata.ProjectName), ResourceType = typeof(ContractsMetadata))]
    public string ProjectName { get; set; }

    [Display(Name = nameof(ContractsMetadata.OrganizationName), ResourceType = typeof(ContractsMetadata))]
    public string OrganizationName { get; set; }

    public CreationTimeDto CreationTime { get; set; }
}

using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;

public class GetTaskDto : TaskBaseDto
{
    [Display(Name = nameof(ContractsMetadata.OrganizationName), ResourceType = typeof(ContractsMetadata))]
    public string CardName { get; set; }

    public string BoardId { get; set; }

    public string ProjectId { get; set; }

    public string OrganizationId { get; set; }

    public CreationTimeDto CreationTime { get; set; }
}

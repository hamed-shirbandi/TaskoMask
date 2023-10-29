using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;

public class GetCardDto : CardBaseDto
{
    [Display(Name = nameof(ContractsMetadata.BoardName), ResourceType = typeof(ContractsMetadata))]
    public string BoardName { get; set; }

    public string ProjectId { get; set; }

    public string OrganizationId { get; set; }

    public string OwnerId { get; set; }

    public CreationTimeDto CreationTime { get; set; }
}

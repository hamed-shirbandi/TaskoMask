using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;

public class UpdateBoardDto
{
    public string Id { get; set; }

    [Display(Name = nameof(ContractsMetadata.Name), ResourceType = typeof(ContractsMetadata))]
    [StringLength(
        DomainConstValues.BOARD_NAME_MAX_LENGTH,
        MinimumLength = DomainConstValues.BOARD_NAME_MIN_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string Name { get; set; }

    [Display(Name = nameof(ContractsMetadata.Description), ResourceType = typeof(ContractsMetadata))]
    [MaxLength(
        DomainConstValues.BOARD_DESCRIPTION_MAX_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Max_Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    public string Description { get; set; }
}

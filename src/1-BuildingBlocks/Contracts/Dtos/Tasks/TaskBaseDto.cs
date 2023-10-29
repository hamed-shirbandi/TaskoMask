using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;

public abstract class TaskBaseDto
{
    public string Id { get; set; }

    [Display(Name = nameof(ContractsMetadata.Title), ResourceType = typeof(ContractsMetadata))]
    [StringLength(
        DomainConstValues.TASK_TITLE_MAX_LENGTH,
        MinimumLength = DomainConstValues.TASK_TITLE_MIN_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string Title { get; set; }

    [Display(Name = nameof(ContractsMetadata.Description), ResourceType = typeof(ContractsMetadata))]
    [MaxLength(
        DomainConstValues.TASK_DESCRIPTION_MAX_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Max_Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    public string Description { get; set; }

    [Display(Name = nameof(ContractsMetadata.CardId), ResourceType = typeof(ContractsMetadata))]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string CardId { get; set; }
}

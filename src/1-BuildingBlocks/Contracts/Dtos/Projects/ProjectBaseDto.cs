using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;

public abstract class ProjectBaseDto
{
    public string Id { get; set; }

    [Display(Name = nameof(ContractsMetadata.Name), ResourceType = typeof(ContractsMetadata))]
    [StringLength(
        DomainConstValues.PROJECT_NAME_MAX_LENGTH,
        MinimumLength = DomainConstValues.PROJECT_NAME_MIN_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string Name { get; set; }

    [Display(Name = nameof(ContractsMetadata.Description), ResourceType = typeof(ContractsMetadata))]
    [MaxLength(
        DomainConstValues.PROJECT_DESCRIPTION_MAX_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Max_Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    public string Description { get; set; }

    [Display(Name = nameof(ContractsMetadata.OrganizationId), ResourceType = typeof(ContractsMetadata))]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string OrganizationId { get; set; }
}

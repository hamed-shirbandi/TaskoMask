using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;

public abstract class OrganizationBaseDto
{
    public string Id { get; set; }

    [Display(Name = nameof(ContractsMetadata.Name), ResourceType = typeof(ContractsMetadata))]
    [StringLength(
        DomainConstValues.ORGANIZATION_NAME_MAX_LENGTH,
        MinimumLength = DomainConstValues.ORGANIZATION_NAME_MIN_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string Name { get; set; }

    [Display(Name = nameof(ContractsMetadata.Description), ResourceType = typeof(ContractsMetadata))]
    [MaxLength(
        DomainConstValues.ORGANIZATION_DESCRIPTION_MAX_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Max_Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    public string Description { get; set; }

    [JsonIgnore]
    public string OwnerId { get; set; }
}

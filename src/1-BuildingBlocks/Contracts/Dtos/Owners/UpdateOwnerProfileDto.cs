using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;

public class UpdateOwnerProfileDto
{
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string Id { get; set; }

    [Display(Name = nameof(ContractsMetadata.DisplayName), ResourceType = typeof(ContractsMetadata))]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    [StringLength(
        DomainConstValues.OWNER_DISPLAYNAME_MAX_LENGTH,
        MinimumLength = DomainConstValues.OWNER_DISPLAYNAME_MIN_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    public string DisplayName { get; set; }

    [Display(Name = nameof(ContractsMetadata.Email), ResourceType = typeof(ContractsMetadata))]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    [StringLength(
        DomainConstValues.OWNER_EMAIL_MAX_LENGTH,
        MinimumLength = DomainConstValues.OWNER_EMAIL_MIN_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    [EmailAddress]
    public string Email { get; set; }
}

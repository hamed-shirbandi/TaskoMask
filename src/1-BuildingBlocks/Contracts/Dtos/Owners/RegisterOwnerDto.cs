using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;

public class RegisterOwnerDto
{
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

    [Display(Name = nameof(ContractsMetadata.Password), ResourceType = typeof(ContractsMetadata))]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    [StringLength(
        DomainConstValues.USER_PASSWORD_MAX_LENGTH,
        MinimumLength = DomainConstValues.USER_PASSWORD_MIN_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = nameof(ContractsMetadata.ConfirmPassword), ResourceType = typeof(ContractsMetadata))]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    [Compare(
        nameof(Password),
        ErrorMessageResourceName = nameof(ContractsMetadata.ComparePasswords),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    public string ConfirmPassword { get; set; }
}

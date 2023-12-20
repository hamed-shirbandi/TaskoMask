using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Owners.RegisterOwner;

public class RegiserOwnerRequest : BaseCommand
{
    public RegiserOwnerRequest(string displayName, string email, string password)
    {
        DisplayName = displayName;
        Email = email;
        Password = password;
    }

    [StringLength(
        DomainConstValues.OWNER_DISPLAYNAME_MAX_LENGTH,
        MinimumLength = DomainConstValues.OWNER_DISPLAYNAME_MIN_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string DisplayName { get; }

    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    [StringLength(
        DomainConstValues.OWNER_EMAIL_MAX_LENGTH,
        MinimumLength = DomainConstValues.OWNER_EMAIL_MIN_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    [EmailAddress]
    public string Email { get; }

    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    [StringLength(
        DomainConstValues.USER_PASSWORD_MAX_LENGTH,
        MinimumLength = DomainConstValues.USER_PASSWORD_MIN_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    public string Password { get; }
}

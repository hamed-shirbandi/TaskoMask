using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Owners.UpdateOwnerProfile;

public class UpdateOwnerProfileRequest : BaseCommand
{
    public UpdateOwnerProfileRequest(string id, string displayName, string email)
    {
        DisplayName = displayName;
        Email = email;
        Id = id;
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
    public string Id { get; }
}

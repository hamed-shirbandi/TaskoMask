using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Organizations.UpdateOrganization;

public class UpdateOrganizationRequest : BaseCommand
{
    public UpdateOrganizationRequest(string id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string Id { get; }

    [StringLength(
        DomainConstValues.ORGANIZATION_NAME_MAX_LENGTH,
        MinimumLength = DomainConstValues.ORGANIZATION_NAME_MIN_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string Name { get; }

    [MaxLength(
        DomainConstValues.ORGANIZATION_DESCRIPTION_MAX_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Max_Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    public string Description { get; }
}

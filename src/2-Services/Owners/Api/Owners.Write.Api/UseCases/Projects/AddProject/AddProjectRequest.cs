using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Projects.AddProject;

public class AddProjectRequest : BaseCommand
{
    public AddProjectRequest(string organizationId, string name, string description)
    {
        OrganizationId = organizationId;
        Name = name;
        Description = description;
    }

    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string OrganizationId { get; }

    [StringLength(
        DomainConstValues.PROJECT_NAME_MAX_LENGTH,
        MinimumLength = DomainConstValues.PROJECT_NAME_MIN_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string Name { get; }

    [MaxLength(
        DomainConstValues.PROJECT_DESCRIPTION_MAX_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Max_Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    public string Description { get; }
}

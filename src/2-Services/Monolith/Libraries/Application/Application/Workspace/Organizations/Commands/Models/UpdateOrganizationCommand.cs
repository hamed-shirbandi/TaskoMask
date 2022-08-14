using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Models
{
    public class UpdateOrganizationCommand : OrganizationBaseCommand
    {
        public UpdateOrganizationCommand(string id, string name, string description)
            : base(name, description)

        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Id { get; }

    }
}

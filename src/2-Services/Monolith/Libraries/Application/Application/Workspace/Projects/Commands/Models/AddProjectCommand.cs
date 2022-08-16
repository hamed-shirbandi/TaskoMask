
using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.Commands.Models
{
    public class AddProjectCommand : ProjectBaseCommand
    {
        public AddProjectCommand(string name, string description, string organizationId)
            : base(name, description)

        {
            OrganizationId = organizationId;

        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string OrganizationId { get; }
    }
}

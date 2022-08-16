using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Models
{
   public class AddOrganizationCommand : OrganizationBaseCommand
    {
        public AddOrganizationCommand(string name, string description, string ownerId)
            :base(name,description)
        {
            OwnerId = ownerId;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string OwnerId { get; }
    }
}

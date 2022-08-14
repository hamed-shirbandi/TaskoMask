using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Models
{
   public class AddOrganizationCommand : OrganizationBaseCommand
    {
        public AddOrganizationCommand(string name, string description, string ownerId)
            :base(name,description)
        {
            OwnerId = ownerId;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string OwnerId { get; }
    }
}

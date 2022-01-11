using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Organizations.Commands.Models
{
   public class CreateOrganizationCommand : OrganizationBaseCommand
    {
        public CreateOrganizationCommand(string name, string description, string ownerMemberId)
            :base(name,description)
        {
            OwnerMemberId = ownerMemberId;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string OwnerMemberId { get; }
    }
}

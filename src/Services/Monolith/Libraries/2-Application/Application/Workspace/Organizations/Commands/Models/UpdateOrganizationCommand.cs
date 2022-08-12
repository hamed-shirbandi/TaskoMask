using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Organizations.Commands.Models
{
    public class UpdateOrganizationCommand : OrganizationBaseCommand
    {
        public UpdateOrganizationCommand(string id, string name, string description)
            : base(name, description)

        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }

    }
}

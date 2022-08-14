
using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.Commands.Models
{
    public class AddProjectCommand : ProjectBaseCommand
    {
        public AddProjectCommand(string name, string description, string organizationId)
            : base(name, description)

        {
            OrganizationId = organizationId;

        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string OrganizationId { get; }
    }
}

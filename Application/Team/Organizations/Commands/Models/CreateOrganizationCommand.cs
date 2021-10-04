using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Team.Organizations.Commands.Models
{
   public class CreateOrganizationCommand : OrganizationBaseCommand
    {
        public CreateOrganizationCommand(string name, string description, string userId)
        {
            Name = name;
            Description = description;
            UserId = userId;
        }

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string UserId { get; private set; }
    }
}

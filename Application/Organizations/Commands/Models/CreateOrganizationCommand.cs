
using TaskoMask.Application.Organizations.Commands.Validations;
using TaskoMask.Application.Core.Commands;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Organizations.Commands.Models
{
   public class CreateOrganizationCommand : OrganizationCommand
    {
        public CreateOrganizationCommand(string name, string description, string userId)
        {
            Name = name;
            Description = description;
            UserId = userId;
        }

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string UserId { get; private set; }

        
        public override bool IsValid()
        {
            ValidationResult = new CreateOrganizationCommandValidation().Validate(this);
            return base.IsValid();
        }
 
    }
}

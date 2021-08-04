
using TaskoMask.Application.Organizations.Commands.Validations;
using TaskoMask.Application.Core.Commands;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Organizations.Commands.Models
{
    public class UpdateOrganizationCommand : OrganizationCommand
    {
        public UpdateOrganizationCommand(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Id { get; private set; }


        public override bool IsValid()
        {
            ValidationResult = new UpdateOrganizationCommandValidation().Validate(this);
            return base.IsValid();
        }
    }
}

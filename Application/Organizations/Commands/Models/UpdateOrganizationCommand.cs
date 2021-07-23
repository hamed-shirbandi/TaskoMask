
using TaskoMask.Application.Organizations.Commands.Validations;
using TaskoMask.Application.Core.Commands;

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

        public string Id { get; private set; }

        public bool IsValid()
        {
             ValidationResult = new UpdateOrganizationCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

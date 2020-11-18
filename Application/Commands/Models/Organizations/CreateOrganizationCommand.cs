
using TaskoMask.Application.Validations.Organizations;

namespace TaskoMask.Application.Commands.Models.Organizations
{
   public class CreateOrganizationCommand : OrganizationCommand
    {
        public CreateOrganizationCommand(string name, string description, string userId)
        {
            Name = name;
            Description = description;
            UserId = userId;
        }

        public string UserId { get; private set; }

        public bool IsValid()
        {
            ValidationResult = new CreateOrganizationCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

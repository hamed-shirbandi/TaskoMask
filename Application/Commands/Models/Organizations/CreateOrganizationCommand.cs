
using TaskoMask.Application.Validations.Organizations;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Organizations
{
   public class CreateOrganizationCommand : OrganizationCommand, ICommandValidaion
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

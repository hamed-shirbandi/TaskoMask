
using TaskoMask.Application.Projects.Commands.Validations;
using TaskoMask.Application.Core.Commands;

namespace TaskoMask.Application.Projects.Commands.Models
{
   public class CreateProjectCommand : ProjectCommand
    {
        public CreateProjectCommand(string name, string description, string organizationId)
        {
            Name = name;
            Description = description;
            OrganizationId = organizationId;
        }

        public bool IsValid()
        {
            ValidationResult = new CreateProjectCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

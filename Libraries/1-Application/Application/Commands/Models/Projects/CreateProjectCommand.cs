
using TaskoMask.Application.Validations.Projects;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Projects
{
   public class CreateProjectCommand : ProjectCommand, ICommandValidaion
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

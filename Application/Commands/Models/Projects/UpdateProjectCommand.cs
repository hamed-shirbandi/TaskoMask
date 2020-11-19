
using TaskoMask.Application.Validations.Projects;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Projects
{
   public class UpdateProjectCommand : ProjectCommand, ICommandValidaion
    {
        public UpdateProjectCommand(string id, string name, string description )
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; private set; }


        public bool IsValid()
        {
            ValidationResult = new UpdateProjectCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

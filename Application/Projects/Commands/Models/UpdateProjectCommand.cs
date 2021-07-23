
using TaskoMask.Application.Projects.Commands.Validations;
using TaskoMask.Application.Core.Commands;

namespace TaskoMask.Application.Projects.Commands.Models
{
   public class UpdateProjectCommand : ProjectCommand
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

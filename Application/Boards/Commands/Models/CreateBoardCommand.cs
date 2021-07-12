
using TaskoMask.Application.Commands.Validations.Boards;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Boards
{
   public class CreateBoardCommand : BoardCommand, ICommandValidaion
    {
        public CreateBoardCommand(string name, string description, string projectId)
        {
            Name = name;
            Description = description;
            ProjectId = projectId;
        }

        public bool IsValid()
        {
            ValidationResult = new CreateBoardCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

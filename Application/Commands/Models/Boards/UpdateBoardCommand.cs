
using TaskoMask.Application.Validations.Boards;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Boards
{
   public class UpdateBoardCommand : BoardCommand, ICommandValidaion
    {
        public UpdateBoardCommand(string id, string name, string description )
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; private set; }


        public bool IsValid()
        {
            ValidationResult = new UpdateBoardCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

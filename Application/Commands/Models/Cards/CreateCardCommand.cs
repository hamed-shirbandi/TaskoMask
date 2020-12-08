
using TaskoMask.Application.Validations.Cards;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Cards
{
   public class CreateCardCommand : CardCommand, ICommandValidaion
    {
        public CreateCardCommand(string name, string description, string projectId)
        {
            Name = name;
            Description = description;
            BoardId = projectId;
        }

        public bool IsValid()
        {
            ValidationResult = new CreateCardCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}


using TaskoMask.Application.Cards.Commands.Validations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Enums;

namespace TaskoMask.Application.Cards.Commands.Models
{
   public class CreateCardCommand : CardCommand
    {
        public CreateCardCommand(string name, string description, string projectId,CardType type)
        {
            Name = name;
            Description = description;
            BoardId = projectId;
            Type = type;
        }

        public bool IsValid()
        {
            ValidationResult = new CreateCardCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}


using TaskoMask.Application.Commands.Validations.Cards;
using TaskoMask.Domain.Core.Commands;
using TaskoMask.Domain.Core.Enums;

namespace TaskoMask.Application.Commands.Models.Cards
{
   public class CreateCardCommand : CardCommand, ICommandValidaion
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

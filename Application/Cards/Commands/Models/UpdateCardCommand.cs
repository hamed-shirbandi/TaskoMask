
using TaskoMask.Application.Cards.Commands.Validations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Enums;

namespace TaskoMask.Application.Cards.Commands.Models
{
   public class UpdateCardCommand : CardCommand
    {
        public UpdateCardCommand(string id, string name, string description, CardType type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
        }

        public string Id { get; private set; }


        public bool IsValid()
        {
            ValidationResult = new UpdateCardCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

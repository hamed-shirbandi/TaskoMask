
using TaskoMask.Application.Commands.Validations.Cards;
using TaskoMask.Domain.Core.Commands;
using TaskoMask.Domain.Core.Enums;

namespace TaskoMask.Application.Commands.Models.Cards
{
   public class UpdateCardCommand : CardCommand, ICommandValidaion
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


using TaskoMask.Application.Validations.Cards;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Cards
{
   public class UpdateCardCommand : CardCommand, ICommandValidaion
    {
        public UpdateCardCommand(string id, string name, string description )
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; private set; }


        public bool IsValid()
        {
            ValidationResult = new UpdateCardCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

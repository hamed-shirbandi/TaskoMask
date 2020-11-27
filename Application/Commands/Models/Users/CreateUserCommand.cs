
using TaskoMask.Application.Validations.Users;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Users
{
   public class CreateUserCommand : UserCommand, ICommandValidaion
    {
        public CreateUserCommand(string displayName)
        {
            DisplayName = displayName;
        }


        public bool IsValid()
        {
            ValidationResult = new CreateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

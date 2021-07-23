
using TaskoMask.Application.Users.Commands.Validations;
using TaskoMask.Application.Core.Commands;

namespace TaskoMask.Application.Users.Commands.Models
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(string id, string displayName,string email)
        {
            Id = id;
            DisplayName = displayName;
            Email = email;
        }

        public string Id { get; private set; }

        public bool IsValid()
        {
            ValidationResult = new UpdateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

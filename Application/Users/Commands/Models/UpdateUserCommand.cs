
using TaskoMask.Application.Commands.Validations.Users;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Users
{
    public class UpdateUserCommand : UserCommand, ICommandValidaion
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

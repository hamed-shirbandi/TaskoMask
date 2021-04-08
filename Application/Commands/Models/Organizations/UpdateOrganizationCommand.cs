
using TaskoMask.Application.Commands.Validations.Organizations;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Organizations
{
    public class UpdateOrganizationCommand : OrganizationCommand, ICommandValidaion
    {
        public UpdateOrganizationCommand(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; private set; }

        public bool IsValid()
        {
             ValidationResult = new UpdateOrganizationCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

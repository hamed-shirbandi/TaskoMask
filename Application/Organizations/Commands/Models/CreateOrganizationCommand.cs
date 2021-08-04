
using TaskoMask.Application.Organizations.Commands.Validations;
using TaskoMask.Application.Core.Commands;

namespace TaskoMask.Application.Organizations.Commands.Models
{
   public class CreateOrganizationCommand : OrganizationCommand
    {
        public CreateOrganizationCommand(string name, string description, string userId)
        {
            Name = name;
            Description = description;
            UserId = userId;
        }

        public string UserId { get; private set; }

    }
}

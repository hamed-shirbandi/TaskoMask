using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Validations
{
   public class AddOrganizationValidation:OrganizationValidation<AddOrganizationCommand>
    {
        public AddOrganizationValidation()
        {
            ValidateDescription();
        }

    }
}

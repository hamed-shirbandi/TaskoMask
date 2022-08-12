using TaskoMask.Application.Workspace.Organizations.Commands.Models;

namespace TaskoMask.Application.Workspace.Organizations.Commands.Validations
{
   public class AddOrganizationValidation:OrganizationValidation<AddOrganizationCommand>
    {
        public AddOrganizationValidation()
        {
            ValidateDescription();
        }

    }
}

using TaskoMask.Application.Workspace.Organizations.Commands.Models;

namespace TaskoMask.Application.Workspace.Organizations.Commands.Validations
{
   public class CreateOrganizationCommandValidation:OrganizationValidation<CreateOrganizationCommand>
    {
        public CreateOrganizationCommandValidation()
        {
            ValidateDescription();
        }

    }
}

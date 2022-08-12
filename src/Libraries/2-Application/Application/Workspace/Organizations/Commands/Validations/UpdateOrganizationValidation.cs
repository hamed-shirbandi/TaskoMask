using TaskoMask.Application.Workspace.Organizations.Commands.Models;

namespace TaskoMask.Application.Workspace.Organizations.Commands.Validations
{
   public class UpdateOrganizationValidation : OrganizationValidation<UpdateOrganizationCommand>
    {
        public UpdateOrganizationValidation()
        {
            ValidateDescription();
        }

    }
}

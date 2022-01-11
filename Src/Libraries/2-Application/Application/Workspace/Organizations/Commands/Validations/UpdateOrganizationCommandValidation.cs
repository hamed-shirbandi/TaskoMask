using TaskoMask.Application.Workspace.Organizations.Commands.Models;

namespace TaskoMask.Application.Workspace.Organizations.Commands.Validations
{
   public class UpdateOrganizationCommandValidation : OrganizationValidation<UpdateOrganizationCommand>
    {
        public UpdateOrganizationCommandValidation()
        {
            ValidateDescription();
        }

    }
}

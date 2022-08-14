using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Validations
{
   public class UpdateOrganizationValidation : OrganizationValidation<UpdateOrganizationCommand>
    {
        public UpdateOrganizationValidation()
        {
            ValidateDescription();
        }

    }
}

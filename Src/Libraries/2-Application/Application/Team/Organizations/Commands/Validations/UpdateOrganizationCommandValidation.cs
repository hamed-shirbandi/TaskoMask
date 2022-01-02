using TaskoMask.Application.Team.Organizations.Commands.Models;

namespace TaskoMask.Application.Team.Organizations.Commands.Validations
{
   public class UpdateOrganizationCommandValidation : OrganizationValidation<UpdateOrganizationCommand>
    {
        public UpdateOrganizationCommandValidation()
        {
            ValidateDescription();
        }

    }
}

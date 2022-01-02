using TaskoMask.Application.Team.Organizations.Commands.Models;

namespace TaskoMask.Application.Team.Organizations.Commands.Validations
{
   public class CreateOrganizationCommandValidation:OrganizationValidation<CreateOrganizationCommand>
    {
        public CreateOrganizationCommandValidation()
        {
            ValidateDescription();
        }

    }
}

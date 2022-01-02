using TaskoMask.Application.Team.Projects.Commands.Models;

namespace TaskoMask.Application.Team.Projects.Commands.Validations
{
   public class CreateProjectCommandValidation:ProjectValidation<CreateProjectCommand>
    {
        public CreateProjectCommandValidation()
        {
            ValidateDescription();
        }

    }
}

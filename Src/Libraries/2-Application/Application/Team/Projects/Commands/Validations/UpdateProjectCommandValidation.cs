using TaskoMask.Application.Team.Projects.Commands.Models;

namespace TaskoMask.Application.Team.Projects.Commands.Validations
{
    public class UpdateProjectCommandValidation : ProjectValidation<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidation()
        {
            ValidateDescription();
        }

    }
}

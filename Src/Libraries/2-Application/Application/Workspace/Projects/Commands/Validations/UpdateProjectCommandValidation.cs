using TaskoMask.Application.Workspace.Projects.Commands.Models;

namespace TaskoMask.Application.Workspace.Projects.Commands.Validations
{
    public class UpdateProjectCommandValidation : ProjectValidation<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidation()
        {
            ValidateDescription();
        }

    }
}

using TaskoMask.Application.Workspace.Projects.Commands.Models;

namespace TaskoMask.Application.Workspace.Projects.Commands.Validations
{
    public class UpdateProjectValidation : ProjectValidation<UpdateProjectCommand>
    {
        public UpdateProjectValidation()
        {
            ValidateDescription();
        }

    }
}

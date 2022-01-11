using TaskoMask.Application.Workspace.Projects.Commands.Models;

namespace TaskoMask.Application.Workspace.Projects.Commands.Validations
{
   public class CreateProjectCommandValidation:ProjectValidation<CreateProjectCommand>
    {
        public CreateProjectCommandValidation()
        {
            ValidateDescription();
        }

    }
}

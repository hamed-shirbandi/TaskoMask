using TaskoMask.Application.Workspace.Projects.Commands.Models;

namespace TaskoMask.Application.Workspace.Projects.Commands.Validations
{
   public class AddProjectValidation:ProjectValidation<AddProjectCommand>
    {
        public AddProjectValidation()
        {
            ValidateDescription();
        }

    }
}

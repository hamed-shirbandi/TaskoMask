using TaskoMask.Services.Monolith.Application.Workspace.Projects.Commands.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.Commands.Validations
{
   public class AddProjectValidation:ProjectValidation<AddProjectCommand>
    {
        public AddProjectValidation()
        {
            ValidateDescription();
        }

    }
}

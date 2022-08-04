using TaskoMask.Application.Workspace.Organizations.Commands.Models;

namespace TaskoMask.Application.Workspace.Organizations.Commands.Validations
{
   public class AddOrganizationToOwnerWorkspaceValidation:OrganizationValidation<AddOrganizationCommand>
    {
        public AddOrganizationToOwnerWorkspaceValidation()
        {
            ValidateDescription();
        }

    }
}

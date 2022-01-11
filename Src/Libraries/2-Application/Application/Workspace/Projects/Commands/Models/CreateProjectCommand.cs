
namespace TaskoMask.Application.Workspace.Projects.Commands.Models
{
    public class CreateProjectCommand : ProjectBaseCommand
    {
        public CreateProjectCommand(string name, string description, string organizationId)
            : base(name, description, organizationId)

        {
        }

    }
}

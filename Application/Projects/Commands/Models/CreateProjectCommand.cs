
namespace TaskoMask.Application.Projects.Commands.Models
{
   public class CreateProjectCommand : ProjectCommand
    {
        public CreateProjectCommand(string name, string description, string organizationId)
        {
            Name = name;
            Description = description;
            OrganizationId = organizationId;
        }

    }
}

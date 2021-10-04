
namespace TaskoMask.Application.Projects.Commands.Models
{
   public class CreateProjectCommand : ProjectBaseCommand
    {
        public CreateProjectCommand(string name, string description, string organizationId)
        {
            Name = name;
            Description = description;
            OrganizationId = organizationId;
        }

    }
}


namespace TaskoMask.Application.Commands.Models.Projects
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

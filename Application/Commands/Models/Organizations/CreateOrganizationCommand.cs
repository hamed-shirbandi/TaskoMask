
namespace TaskoMask.Application.Commands.Models.Organizations
{
   public class CreateOrganizationCommand : OrganizationCommand
    {
        public CreateOrganizationCommand(string name, string description, string userId)
        {
            Name = name;
            Description = description;
            UserId = userId;
        }  
    }
}

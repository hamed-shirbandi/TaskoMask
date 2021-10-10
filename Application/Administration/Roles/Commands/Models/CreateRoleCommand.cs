
namespace TaskoMask.Application.Administration.Roles.Commands.Models
{
   public class CreateRoleCommand : RoleBaseCommand
    {
        public CreateRoleCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}

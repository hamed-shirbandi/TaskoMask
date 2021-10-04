
namespace TaskoMask.Application.Team.Managers.Commands.Models
{
   public class CreateManagerCommand : ManagerBaseCommand
    {
        public CreateManagerCommand(string displayName,string email,string password)
        {
            DisplayName = displayName;
            Email = email;
            Password = password;
        }


    }
}


namespace TaskoMask.Application.Users.Commands.Models
{
   public class CreateUserCommand : UserCommand
    {
        public CreateUserCommand(string displayName,string email,string password)
        {
            DisplayName = displayName;
            Email = email;
            Password = password;
        }


    }
}

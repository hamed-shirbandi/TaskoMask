
namespace TaskoMask.Application.Operators.Commands.Models
{
   public class CreateOperatorCommand : OperatorCommand
    {
        public CreateOperatorCommand(string displayName,string email,string password)
        {
            DisplayName = displayName;
            Email = email;
            Password = password;
        }


    }
}

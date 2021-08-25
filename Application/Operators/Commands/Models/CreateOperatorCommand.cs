
namespace TaskoMask.Application.Operators.Commands.Models
{
   public class CreateOperatorCommand : OperatorBaseCommand
    {
        public CreateOperatorCommand(string displayName,string email,string password)
        {
            DisplayName = displayName;
            Email = email;
            Password = password;
        }


    }
}

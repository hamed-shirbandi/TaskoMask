
namespace TaskoMask.Application.Team.Members.Commands.Models
{
   public class CreateMemberCommand : MemberBaseCommand
    {
        public CreateMemberCommand(string displayName,string email,string password)
        {
            DisplayName = displayName;
            Email = email;
            Password = password;
        }


    }
}

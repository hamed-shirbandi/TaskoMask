
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Team.Members.Commands.Models
{
   public class CreateMemberCommand : MemberBaseCommand
    {
        public CreateMemberCommand(string displayName, string email,string password)
            :base(displayName,email)
        {
            Password = password;
        }

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Password { get; }
    }
}

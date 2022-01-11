
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Members.Commands.Models
{
   public class CreateMemberCommand : MemberBaseCommand
    {
        public CreateMemberCommand(string displayName, string email,string password)
            :base(displayName,email)
        {
            Password = password;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Password { get; }
    }
}

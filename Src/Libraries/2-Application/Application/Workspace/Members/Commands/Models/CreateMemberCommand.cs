
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Helpers;
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
        [StringLength(DomainConstValues.Member_Password_Max_Length, MinimumLength = DomainConstValues.Member_Password_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Password { get; }
    }
}

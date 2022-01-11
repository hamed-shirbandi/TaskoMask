using TaskoMask.Application.Core.Commands;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Share.Helpers;

namespace TaskoMask.Application.Workspace.Members.Commands.Models
{
    public abstract class MemberBaseCommand : BaseCommand
    {
        public MemberBaseCommand(string displayName, string email)
        {
            DisplayName = displayName;
            Email = email;
        }

        [StringLength(DomainConstValues.Member_DisplayName_Max_Length, MinimumLength = DomainConstValues.Member_DisplayName_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string DisplayName { get; }
       
        
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [StringLength(DomainConstValues.Member_Email_Max_Length, MinimumLength = DomainConstValues.Member_Email_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [EmailAddress]
        public string Email { get; }

    }
}

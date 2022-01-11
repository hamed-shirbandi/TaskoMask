using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Members.Commands.Models
{
    public class UpdateMemberCommand : MemberBaseCommand
    {
        public UpdateMemberCommand(string id, string displayName, string email, string phoneNumber)
              : base(displayName, email)
        {
            Id = id;
            PhoneNumber = phoneNumber;

        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }

        [Display(Name = nameof(ApplicationMetadata.PhoneNumber), ResourceType = typeof(ApplicationMetadata))]
        public string PhoneNumber { get; }

    }
}

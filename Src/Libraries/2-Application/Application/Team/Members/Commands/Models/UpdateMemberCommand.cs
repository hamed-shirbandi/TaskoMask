using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Team.Members.Commands.Models
{
    public class UpdateMemberCommand : MemberBaseCommand
    {
        public UpdateMemberCommand(string id, string displayName, string email, string phoneNumber)
              : base(displayName, email)
        {
            Id = id;
            PhoneNumber = phoneNumber;

        }

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Id { get; }

        [Display(Name = nameof(ApplicationMetadata.PhoneNumber), ResourceType = typeof(ApplicationMetadata))]
        public string PhoneNumber { get; }

    }
}

using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Members
{
    public class MemberRegisterDto
    {
        [Display(Name = nameof(ApplicationMetadata.DisplayName), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string DisplayName { get; set; }



        [Display(Name = nameof(ApplicationMetadata.Email), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = nameof(ApplicationMetadata.PhoneNumber), ResourceType = typeof(ApplicationMetadata))]
        public string PhoneNumber { get; }

        [Display(Name = nameof(ApplicationMetadata.Password), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [DataType(DataType.Password)]
        [Display(Name = nameof(ApplicationMetadata.ConfirmPassword), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [Compare(nameof(Password), ErrorMessageResourceName = nameof(ApplicationMetadata.ComparePasswords), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string ConfirmPassword { get; set; }

    }
}

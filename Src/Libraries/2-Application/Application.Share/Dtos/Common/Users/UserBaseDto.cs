using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Common.Users
{
    public abstract class UserBaseDto
    {
        public string Id { get; set; }


        [Display(Name = nameof(ApplicationMetadata.DisplayName), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [StringLength(DomainConstValues.Member_DisplayName_Max_Length, MinimumLength = DomainConstValues.Member_DisplayName_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        public string DisplayName { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Email), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [StringLength(DomainConstValues.Member_Email_Max_Length, MinimumLength = DomainConstValues.Member_Email_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = nameof(ApplicationMetadata.PhoneNumber), ResourceType = typeof(ApplicationMetadata))]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [Display(Name = nameof(ApplicationMetadata.UserName), ResourceType = typeof(ApplicationMetadata))]
        [StringLength(DomainConstValues.Member_Email_Max_Length, MinimumLength = DomainConstValues.Member_Email_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string UserName { get; set; }


        public bool IsActive { get; set; }

    }

}

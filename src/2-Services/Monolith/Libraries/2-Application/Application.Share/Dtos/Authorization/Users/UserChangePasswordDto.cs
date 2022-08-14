using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Application.Share.Resources;
using TaskoMask.Services.Monolith.Domain.Share.Helpers;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Share.Dtos.Authorization.Users
{
    public class UserChangePasswordDto
    {
        public string Id { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = nameof(ApplicationMetadata.User_OldPassword), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string OldPassword { get; set; }



        [DataType(DataType.Password)]
        [Display(Name = nameof(ApplicationMetadata.User_NewPassword), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [StringLength(DomainConstValues.User_Password_Max_Length, MinimumLength = DomainConstValues.User_Password_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        public string NewPassword { get; set; }



        [DataType(DataType.Password)]
        [Display(Name = nameof(ApplicationMetadata.User_ConfirmNewPassword), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [Compare(nameof(NewPassword), ErrorMessageResourceName = nameof(ApplicationMetadata.User_ConfirmPassword_Not_Match), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string ConfirmNewPassword { get; set; }
    }
}

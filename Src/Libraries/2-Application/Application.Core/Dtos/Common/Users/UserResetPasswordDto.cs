using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Common.Users
{
    public class UserResetPasswordDto
    {

        public string Id { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = nameof(ApplicationMetadata.User_NewPassword), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string NewPassword { get; set; }



        [DataType(DataType.Password)]
        [Display(Name = nameof(ApplicationMetadata.User_ConfirmNewPassword), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [Compare(nameof(NewPassword), ErrorMessageResourceName = nameof(ApplicationMetadata.User_ConfirmPassword_Not_Match), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string ConfirmNewPassword { get; set; }


    }
}

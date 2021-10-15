using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Common.BaseUsers.Commands.Models
{
    public class ChangeUserPasswordCommand<TEntity> : BaseCommand where TEntity:BaseUser
    {
        public ChangeUserPasswordCommand(string id, string oldPassword, string newPassword, string confirmPassword)
        {
            Id = id;
            OldPassword = oldPassword;
            NewPassword = newPassword;
            ConfirmNewPassword = confirmPassword;
        }


        public string Id { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = nameof(ApplicationMetadata.User_OldPassword), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string OldPassword { get; set; }



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

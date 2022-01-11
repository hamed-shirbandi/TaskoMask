using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Common.Users
{
   public class UserUpsertDto: UserBaseDto
    {
        [Display(Name = nameof(ApplicationMetadata.Password), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [StringLength(DomainConstValues.Member_Password_Max_Length, MinimumLength = DomainConstValues.Member_Password_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = nameof(ApplicationMetadata.ConfirmPassword), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [Compare(nameof(Password), ErrorMessageResourceName  = nameof(ApplicationMetadata.ComparePasswords), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string ConfirmPassword { get; set; }

    }
}

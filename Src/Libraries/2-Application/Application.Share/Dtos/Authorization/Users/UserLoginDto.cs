using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Authorization.Users
{
    public class UserLoginDto
    {

        [Display(Name = nameof(ApplicationMetadata.UserName), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string UserName { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Password), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [StringLength(DomainConstValues.User_Password_Max_Length, MinimumLength = DomainConstValues.User_Password_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [DataType(DataType.Password)]
        public string Password { get; set; }


       
        /// <summary>
        /// use in cookie authentication
        /// </summary>
        [Display(Name = nameof(ApplicationMetadata.ReownerMe), ResourceType = typeof(ApplicationMetadata))]
        public bool ReownerMe { get; set; }

    }
}

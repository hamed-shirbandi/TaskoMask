using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Common.Users
{
    public class UserLoginDto
    {

        [Display(Name = nameof(ApplicationMetadata.Email), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Password), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [DataType(DataType.Password)]
        public string Password { get; set; }


       
        /// <summary>
        /// use in cookie authentication
        /// </summary>
        [Display(Name = nameof(ApplicationMetadata.RememberMe), ResourceType = typeof(ApplicationMetadata))]
        public bool RememberMe { get; set; }

    }
}

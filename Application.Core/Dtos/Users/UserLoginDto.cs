using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Users
{
    public class UserLoginDto
    {

        [Display(Name = nameof(ApplicationMetadata.Email), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Password), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [DataType(DataType.Password)]
        public string Password { get; set; }


       
        /// <summary>
        /// use in cookie authentication
        /// </summary>
        [Display(Name = nameof(ApplicationMetadata.RememberMe), ResourceType = typeof(ApplicationMetadata))]
        public bool RememberMe { get; set; }

    }
}

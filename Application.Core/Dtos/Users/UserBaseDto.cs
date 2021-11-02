using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Users
{
    public abstract class UserBaseDto
    {
        public string Id { get; set; }


        [Display(Name = nameof(ApplicationMetadata.DisplayName), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string DisplayName { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Email), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Email { get; set; }


        [Display(Name = nameof(ApplicationMetadata.PhoneNumber), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string PhoneNumber { get; set; }


        [Display(Name = nameof(ApplicationMetadata.UserName), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string UserName { get; set; }


        public bool IsActive { get; set; }

    }

}

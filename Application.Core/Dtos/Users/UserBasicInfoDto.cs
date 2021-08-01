using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Users
{
   public class UserBasicInfoDto: UserBaseDto
    {
        public CreationTimeDto CreationTime { get; set; }
    }



    public abstract class UserBaseDto
    {
        public string Id { get; set; }


        [Display(Name = nameof(ApplicationMetadata.DisplayName), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string DisplayName { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Email), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Email { get; set; }
    }

}

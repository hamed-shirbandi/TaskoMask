using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Dtos.Base;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Users
{
    public class UserBasicInfoDto: UserBaseDto
    {
        [Display(Name = nameof(ApplicationMetadata.UserName), ResourceType = typeof(ApplicationMetadata))]
        public string UserName { get; set; }

        
        public CreationTimeDto CreationTime { get; set; }
       
        public string AvatarUrl { get; set; }
    }
}

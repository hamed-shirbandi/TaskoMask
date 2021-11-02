using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Dtos.Base;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Users
{
    public class UserBasicInfoDto: UserBaseDto
    {
        public CreationTimeDto CreationTime { get; set; }
       
        public string AvatarUrl { get; set; }


    }
}

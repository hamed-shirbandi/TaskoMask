using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Dtos.Common.Base;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Common.Users
{
    public class UserBasicInfoDto: UserBaseDto
    {
        public CreationTimeDto CreationTime { get; set; }
       
        public string AvatarUrl { get; set; }


    }
}

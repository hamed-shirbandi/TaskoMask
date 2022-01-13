using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Dtos.Common;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Authorization.Users
{
    public class UserBasicInfoDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }
        public bool IsActive { get; set; }

        public CreationTimeDto CreationTime { get; set; }

    }
}

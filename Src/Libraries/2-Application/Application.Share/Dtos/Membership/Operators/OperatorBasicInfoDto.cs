using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Share.Dtos.Common;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Membership.Operators
{
    public class OperatorBasicInfoDto 
    {
        public string Id { get; set; }
        public UserBasicInfoDto UserInfo { get; set; }

        public CreationTimeDto CreationTime { get; set; }


        [Display(Name = nameof(ApplicationMetadata.DisplayName), ResourceType = typeof(ApplicationMetadata))]
        public string DisplayName { get; set; }



        [Display(Name = nameof(ApplicationMetadata.RolesId), ResourceType = typeof(ApplicationMetadata))]
        public string[] RolesId { get; set; }

    }
}

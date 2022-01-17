using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Share.Dtos.Common;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Owners
{
    public class OwnerBasicInfoDto 
    {
        public string Id { get; set; }

        public UserBasicInfoDto UserInfo { get; set; }

        public CreationTimeDto CreationTime { get; set; }


        [Display(Name = nameof(ApplicationMetadata.DisplayName), ResourceType = typeof(ApplicationMetadata))]
        public string DisplayName { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Email), ResourceType = typeof(ApplicationMetadata))]
        public string Email { get; set; }

    }
}

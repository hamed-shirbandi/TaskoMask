using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Common;
using TaskoMask.Services.Monolith.Application.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Owners
{
    public class OwnerBasicInfoDto 
    {
        public string Id { get; set; }

        public CreationTimeDto CreationTime { get; set; }

        [Display(Name = nameof(ApplicationMetadata.DisplayName), ResourceType = typeof(ApplicationMetadata))]
        public string DisplayName { get; set; }

        [Display(Name = nameof(ApplicationMetadata.Email), ResourceType = typeof(ApplicationMetadata))]
        public string Email { get; set; }

        public UserBasicInfoDto UserInfo { get; set; }


    }
}

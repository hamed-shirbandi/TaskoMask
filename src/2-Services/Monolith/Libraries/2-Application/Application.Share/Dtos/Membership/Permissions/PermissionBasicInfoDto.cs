

using TaskoMask.Services.Monolith.Application.Share.Resources;
using System.ComponentModel.DataAnnotations;

namespace TaskoMask.Services.Monolith.Application.Share.Dtos.Membership.Permissions
{
    public class PermissionBasicInfoDto
    {

        public string Id { get; set; }

        [Display(Name = nameof(ApplicationMetadata.Name), ResourceType = typeof(ApplicationMetadata))]
        public string DisplayName { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Permission_SystemName), ResourceType = typeof(ApplicationMetadata))]
        public string SystemName { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Permission_GroupName), ResourceType = typeof(ApplicationMetadata))]
        public string GroupName { get; set; }
    }
}

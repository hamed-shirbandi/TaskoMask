

using TaskoMask.Application.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace TaskoMask.Application.Core.Dtos.Permissions
{
    public class PermissionBasicInfoDto
    {

        public string Id { get; set; }

        [Display(Name = nameof(ApplicationMetadata.Name), ResourceType = typeof(ApplicationMetadata))]
        public string DisplayName { get; protected set; }


        [Display(Name = nameof(ApplicationMetadata.Permission_SystemName), ResourceType = typeof(ApplicationMetadata))]
        public string SystemName { get; protected set; }


        [Display(Name = nameof(ApplicationMetadata.Permission_GroupName), ResourceType = typeof(ApplicationMetadata))]
        public string GroupName { get; protected set; }
    }
}

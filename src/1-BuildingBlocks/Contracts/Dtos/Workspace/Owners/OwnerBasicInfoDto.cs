using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners
{
    public class OwnerBasicInfoDto 
    {
        public string Id { get; set; }

        public CreationTimeDto CreationTime { get; set; }

        [Display(Name = nameof(ContractsMetadata.DisplayName), ResourceType = typeof(ContractsMetadata))]
        public string DisplayName { get; set; }

        [Display(Name = nameof(ContractsMetadata.Email), ResourceType = typeof(ContractsMetadata))]
        public string Email { get; set; }

        public UserBasicInfoDto UserInfo { get; set; }


    }
}

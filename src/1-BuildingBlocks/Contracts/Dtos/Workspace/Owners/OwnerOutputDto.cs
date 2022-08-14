
using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners
{
    public class OwnerOutputDto : OwnerBasicInfoDto
    {
        /// <summary>
        /// Owner Organizations count as an owner or as an invited owner
        /// </summary>
        [Display(Name = nameof(ContractsMetadata.OrganizationsCount), ResourceType = typeof(ContractsMetadata))]
        public long OrganizationsCount { get; set; }

    }
}

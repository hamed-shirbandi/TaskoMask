
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Owners
{
    public class OwnerOutputDto : OwnerBasicInfoDto
    {
        /// <summary>
        /// Owner Organizations count as an owner or as an invited owner
        /// </summary>
        [Display(Name = nameof(ApplicationMetadata.OrganizationsCount), ResourceType = typeof(ApplicationMetadata))]
        public long OrganizationsCount { get; set; }

    }
}

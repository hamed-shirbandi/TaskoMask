using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Team.Organizations
{
    public class OrganizationOutputDto : OrganizationBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.ProjectsCount), ResourceType = typeof(ApplicationMetadata))]
        public long ProjectsCount { get; set; }
        [Display(Name = nameof(ApplicationMetadata.OwnerDisplayName), ResourceType = typeof(ApplicationMetadata))]
        public string OwnerMemberDisplayName { get; set; }
    }
}

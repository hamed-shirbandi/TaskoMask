using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Team.Organizations
{
    public class OrganizationOutputDto : OrganizationBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.ProjectsCount), ResourceType = typeof(ApplicationMetadata))]
        public int ProjectsCount { get; set; }
        [Display(Name = nameof(ApplicationMetadata.OwnerDisplayName), ResourceType = typeof(ApplicationMetadata))]
        public string OwnerMemberDisplayName { get; set; }
    }
}

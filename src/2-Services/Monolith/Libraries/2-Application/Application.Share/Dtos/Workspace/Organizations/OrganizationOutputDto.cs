using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Application.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Organizations
{
    public class OrganizationOutputDto : OrganizationBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.ProjectsCount), ResourceType = typeof(ApplicationMetadata))]
        public long ProjectsCount { get; set; }
        [Display(Name = nameof(ApplicationMetadata.OwnerDisplayName), ResourceType = typeof(ApplicationMetadata))]
        public string OwnerOwnerDisplayName { get; set; }
    }
}

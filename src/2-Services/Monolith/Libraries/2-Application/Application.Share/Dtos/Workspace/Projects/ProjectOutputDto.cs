using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Application.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Projects
{
   public class ProjectOutputDto: ProjectBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.OrganizationName), ResourceType = typeof(ApplicationMetadata))]
        public string OrganizationName { get; set; }

        [Display(Name = nameof(ApplicationMetadata.BoardsCount), ResourceType = typeof(ApplicationMetadata))]
        public long BoardsCount { get; set; }
    }
}

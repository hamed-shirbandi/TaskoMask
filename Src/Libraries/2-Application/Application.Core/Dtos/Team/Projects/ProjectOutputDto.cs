using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Team.Projects
{
   public class ProjectOutputDto: ProjectBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.OrganizationName), ResourceType = typeof(ApplicationMetadata))]
        public string OrganizationName { get; set; }

        [Display(Name = nameof(ApplicationMetadata.BoardsCount), ResourceType = typeof(ApplicationMetadata))]
        public int BoardsCount { get; set; }
    }
}

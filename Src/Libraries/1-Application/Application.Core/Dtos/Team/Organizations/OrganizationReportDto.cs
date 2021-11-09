using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Dtos.Team.Projects;
using TaskoMask.Application.Core.Dtos.Workspace.Tasks;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Team.Organizations
{
   public class OrganizationReportDto : ProjectReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.ProjectsCount), ResourceType = typeof(ApplicationMetadata))]
        public int ProjectsCount { get; set; }

    }
}

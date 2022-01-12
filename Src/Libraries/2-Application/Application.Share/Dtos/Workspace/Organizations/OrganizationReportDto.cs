using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Organizations
{
   public class OrganizationReportDto : ProjectReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.ProjectsCount), ResourceType = typeof(ApplicationMetadata))]
        public int ProjectsCount { get; set; }

    }
}

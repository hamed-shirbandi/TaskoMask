using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Services.Monolith.Application.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Organizations
{
   public class OrganizationReportDto : ProjectReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.ProjectsCount), ResourceType = typeof(ApplicationMetadata))]
        public long ProjectsCount { get; set; }

    }
}

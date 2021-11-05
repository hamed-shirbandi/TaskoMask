using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Dtos.TaskManagement.Tasks;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Team.Organizations
{
   public class OrganizationReportDto : TaskReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.ProjectsCount), ResourceType = typeof(ApplicationMetadata))]
        public int ProjectsCount { get; set; }
       
        [Display(Name = nameof(ApplicationMetadata.MembersCount), ResourceType = typeof(ApplicationMetadata))]
        public int MembersCount { get; set; }

    }
}

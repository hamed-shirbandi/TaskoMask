using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Dtos.Tasks;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Organizations
{
   public class OrganizationReportDto : TaskReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.ProjectsCount), ResourceType = typeof(ApplicationMetadata))]
        public int ProjectsCount { get; set; }
       
        [Display(Name = nameof(ApplicationMetadata.ManagersCount), ResourceType = typeof(ApplicationMetadata))]
        public int ManagersCount { get; set; }

    }
}

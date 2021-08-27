using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Application.Core.Dtos.Tasks;

namespace TaskoMask.Application.Core.ViewModels
{
   public class OrganizationDetailsViewModel
    {
        public OrganizationBasicInfoDto Organization { get; set; }
        public OrganizationReportDto Reports { get; set; }
        public IEnumerable<ProjectBasicInfoDto> Projects { get; set; }
        public IEnumerable<TaskBasicInfoDto> LastTasks { get; set; }
    }
}

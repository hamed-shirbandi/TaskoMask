using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.TaskManagement.Boards;
using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Dtos.Team.Projects;
using TaskoMask.Application.Core.Dtos.TaskManagement.Tasks;

namespace TaskoMask.Application.Core.ViewModels
{
   public class OrganizationDetailsViewModel
    {
        public OrganizationDetailsViewModel()
        {
            LastTasks = new List<TaskBasicInfoDto>();
        }
        public OrganizationBasicInfoDto Organization { get; set; }
        public OrganizationReportDto Reports { get; set; }
        public IEnumerable<ProjectBasicInfoDto> Projects { get; set; }
        public IEnumerable<BoardBasicInfoDto> Boards { get; set; }
        public IEnumerable<TaskBasicInfoDto> LastTasks { get; set; }
    }
}

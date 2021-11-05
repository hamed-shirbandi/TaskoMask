using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.TaskManagement.Boards;
using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Dtos.Team.Projects;

namespace TaskoMask.Application.Core.ViewModels
{
   public class ProjectDetailsViewModel
    {
        public OrganizationBasicInfoDto Organization { get; set; }
        public ProjectBasicInfoDto Project { get; set; }
        public ProjectReportDto Reports { get; set; }
        public IEnumerable<BoardBasicInfoDto> Boards { get; set; }
    }
}

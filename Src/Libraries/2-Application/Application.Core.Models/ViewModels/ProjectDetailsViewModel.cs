using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Dtos.Team.Organizations;
using TaskoMask.Application.Share.Dtos.Team.Projects;

namespace TaskoMask.Application.Share.ViewModels
{
   public class ProjectDetailsViewModel
    {
        public OrganizationBasicInfoDto Organization { get; set; }
        public ProjectBasicInfoDto Project { get; set; }
        public ProjectReportDto Reports { get; set; }
        public IEnumerable<BoardBasicInfoDto> Boards { get; set; }
    }
}

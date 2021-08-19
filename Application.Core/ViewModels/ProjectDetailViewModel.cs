using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Dtos.Projects;

namespace TaskoMask.Application.Core.ViewMoldes
{
   public class ProjectDetailViewModel
    {
        public OrganizationBasicInfoDto Organization { get; set; }
        public ProjectBasicInfoDto Project { get; set; }
        public ProjectReportDto Reports { get; set; }
        public IEnumerable<BoardBasicInfoDto> Boards { get; set; }
    }
}

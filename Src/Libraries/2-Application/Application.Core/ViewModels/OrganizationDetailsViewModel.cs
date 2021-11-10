using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Workspace.Boards;
using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Dtos.Team.Projects;
using TaskoMask.Application.Core.Dtos.Workspace.Tasks;
using TaskoMask.Application.Core.Dtos.Team.Members;

namespace TaskoMask.Application.Core.ViewModels
{
   public class OrganizationDetailsViewModel
    {
        public OrganizationDetailsViewModel()
        {
            LastTasks = new List<TaskBasicInfoDto>();
        }
        public OrganizationBasicInfoDto Organization { get; set; }
        public MemberBasicInfoDto OwnerMember { get; set; }
        public IEnumerable<MemberBasicInfoDto> Members { get; set; }
        public OrganizationReportDto Reports { get; set; }
        public IEnumerable<ProjectBasicInfoDto> Projects { get; set; }
        public IEnumerable<BoardBasicInfoDto> Boards { get; set; }
        public IEnumerable<TaskBasicInfoDto> LastTasks { get; set; }
    }
}

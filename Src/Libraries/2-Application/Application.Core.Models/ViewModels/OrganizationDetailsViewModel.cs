using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Dtos.Team.Organizations;
using TaskoMask.Application.Share.Dtos.Team.Projects;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Dtos.Team.Members;

namespace TaskoMask.Application.Share.ViewModels
{
   public class OrganizationDetailsViewModel
    {
        public OrganizationDetailsViewModel()
        {
            Members = new List<MemberBasicInfoDto>();
            Projects = new List<ProjectBasicInfoDto>();
            Boards = new List<BoardBasicInfoDto>();
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

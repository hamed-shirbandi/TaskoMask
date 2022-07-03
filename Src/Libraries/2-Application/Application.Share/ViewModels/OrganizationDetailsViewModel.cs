using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;

namespace TaskoMask.Application.Share.ViewModels
{
   public class OrganizationDetailsViewModel
    {
        public OrganizationDetailsViewModel()
        {
            Owners = new List<OwnerBasicInfoDto>();
            Projects = new List<ProjectBasicInfoDto>();
            Boards = new List<BoardBasicInfoDto>();
            PendingTasks = new List<TaskBasicInfoDto>();
        }
        public OrganizationBasicInfoDto Organization { get; set; }
        public OwnerBasicInfoDto OwnerOwner { get; set; }
        public IEnumerable<OwnerBasicInfoDto> Owners { get; set; }
        public OrganizationReportDto Reports { get; set; }
        public IEnumerable<ProjectBasicInfoDto> Projects { get; set; }
        public IEnumerable<BoardBasicInfoDto> Boards { get; set; }
        public IEnumerable<TaskBasicInfoDto> PendingTasks { get; set; }
    }
}

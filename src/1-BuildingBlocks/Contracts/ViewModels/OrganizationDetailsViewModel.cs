using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Projects;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using System.Collections.Generic;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
   public class OrganizationDetailsViewModel
    {
        public OrganizationDetailsViewModel()
        {
            Projects = new List<ProjectBasicInfoDto>();
            Boards = new List<BoardBasicInfoDto>();
        }
        public OrganizationBasicInfoDto Organization { get; set; }
        public OrganizationReportDto Reports { get; set; }
        public IEnumerable<ProjectBasicInfoDto> Projects { get; set; }
        public IEnumerable<BoardBasicInfoDto> Boards { get; set; }
    }
}

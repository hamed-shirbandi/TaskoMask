using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using System.Collections.Generic;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
   public class OrganizationDetailsViewModel
    {
        public OrganizationDetailsViewModel()
        {
            Projects = new List<GetProjectDto>();
            Boards = new List<GetBoardDto>();
        }
        public GetOrganizationDto Organization { get; set; }
        public OrganizationReportDto Reports { get; set; }
        public IEnumerable<GetProjectDto> Projects { get; set; }
        public IEnumerable<GetBoardDto> Boards { get; set; }
    }
}

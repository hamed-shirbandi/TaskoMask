using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Share.Dtos.Workspace.Projects;

namespace TaskoMask.Application.Share.ViewModels
{
   public class BoardDetailsViewModel
    {
        public OrganizationBasicInfoDto Organization { get; set; }
        public ProjectBasicInfoDto Project { get; set; }
        public BoardBasicInfoDto Board { get; set; }
        public BoardReportDto Reports { get; set; }
        public IEnumerable<CardBasicInfoDto> Cards { get; set; }
    }
}

using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Share.Dtos.Team.Organizations;
using TaskoMask.Application.Share.Dtos.Team.Projects;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;

namespace TaskoMask.Application.Share.ViewModels
{
   public class CardDetailsViewModel
    {
        public OrganizationBasicInfoDto Organization { get; set; }
        public ProjectBasicInfoDto Project { get; set; }
        public BoardBasicInfoDto Board { get; set; }
        public CardBasicInfoDto Card { get; set; }
        public CardReportDto Reports { get; set; }
        public IEnumerable<TaskBasicInfoDto> Tasks { get; set; }
    }
}

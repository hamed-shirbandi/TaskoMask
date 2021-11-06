using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Workspace.Boards;
using TaskoMask.Application.Core.Dtos.Workspace.Cards;
using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Dtos.Team.Projects;
using TaskoMask.Application.Core.Dtos.Workspace.Tasks;

namespace TaskoMask.Application.Core.ViewModels
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

using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Application.Core.Dtos.Tasks;

namespace TaskoMask.Application.Core.ViewModels
{
   public class CardDetailViewModel
    {
        public OrganizationBasicInfoDto Organization { get; set; }
        public ProjectBasicInfoDto Project { get; set; }
        public BoardBasicInfoDto Board { get; set; }
        public CardBasicInfoDto Card { get; set; }
        public CardReportDto Reports { get; set; }
        public IEnumerable<TaskBasicInfoDto> Tasks { get; set; }
    }
}

using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Dtos.Projects;

namespace TaskoMask.Application.Core.ViewModels
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

using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.Dtos.Projects;

namespace TaskoMask.Application.Core.ViewMoldes
{
   public class BoardDetailViewModel
    {
        public BoardBasicInfoDto Board { get; set; }
        public BoardReportDto Reports { get; set; }
        public IEnumerable<CardBasicInfoDto> Cards { get; set; }
    }
}

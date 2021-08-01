using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.Dtos.Tasks;

namespace TaskoMask.Application.Core.ViewMoldes
{
   public class CardDetailViewModel
    {
        public CardBasicInfoDto Card { get; set; }
        public TaskReportDto Reports { get; set; }
        public IEnumerable<TaskBasicInfoDto> Tasks { get; set; }
    }
}

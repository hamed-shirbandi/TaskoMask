using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Tasks;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Boards
{
   public class BoardReportDto: TaskReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.CardsCount), ResourceType = typeof(ApplicationMetadata))]
        public int CardsCount { get; set; }
    }
}

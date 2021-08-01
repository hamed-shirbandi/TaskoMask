using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.Dtos.Tasks;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Projects
{
   public class ProjectReportDto : TaskReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.BoardsCount), ResourceType = typeof(ApplicationMetadata))]
        public int BoardsCount { get; set; }

    }
}

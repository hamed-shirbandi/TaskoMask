using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.Dtos.Projects;

namespace TaskoMask.Application.Core.ViewMoldes
{
   public class BoardListViewModel
    {
        public ProjectOutput Project { get; set; }
        public IEnumerable<BoardBasicInfoDto> Boards { get; set; }
    }
}

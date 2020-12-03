using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Application.Services.Boards.Dto;
using TaskoMask.Application.Services.Projects.Dto;

namespace TaskoMask.Application.ViewMoldes
{
   public class BoardListViewModel
    {
        public ProjectOutput Project { get; set; }
        public IEnumerable<BoardOutput> Boards { get; set; }
    }
}

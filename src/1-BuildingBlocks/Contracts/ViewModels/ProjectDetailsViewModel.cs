using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
   public class ProjectDetailsViewModel
    {
        public GetProjectDto Project { get; set; }
        public IEnumerable<GetBoardDto> Boards { get; set; }
    }
}

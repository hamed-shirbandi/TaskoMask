using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Projects;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
   public class ProjectDetailsViewModel
    {
        public ProjectOutputDto Project { get; set; }
        public IEnumerable<BoardBasicInfoDto> Boards { get; set; }
    }
}

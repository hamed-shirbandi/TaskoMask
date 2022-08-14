using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Projects;

namespace TaskoMask.Services.Monolith.Application.Share.ViewModels
{
   public class ProjectDetailsViewModel
    {
        public ProjectOutputDto Project { get; set; }
        public IEnumerable<BoardBasicInfoDto> Boards { get; set; }
    }
}

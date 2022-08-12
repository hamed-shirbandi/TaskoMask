using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Dtos.Workspace.Projects;

namespace TaskoMask.Application.Share.ViewModels
{
   public class ProjectDetailsViewModel
    {
        public ProjectOutputDto Project { get; set; }
        public IEnumerable<BoardBasicInfoDto> Boards { get; set; }
    }
}

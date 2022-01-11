using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Projects
{
   public class ProjectReportDto : BoardReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.BoardsCount), ResourceType = typeof(ApplicationMetadata))]
        public int BoardsCount { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Dtos.TaskManagement.Tasks;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Team.Projects
{
   public class ProjectReportDto : TaskReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.BoardsCount), ResourceType = typeof(ApplicationMetadata))]
        public int BoardsCount { get; set; }

    }
}

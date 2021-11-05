using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Dtos.TaskManagement.Tasks;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.TaskManagement.Boards
{
    public class BoardReportDto: TaskReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.CardsCount), ResourceType = typeof(ApplicationMetadata))]
        public int CardsCount { get; set; }
    }
}

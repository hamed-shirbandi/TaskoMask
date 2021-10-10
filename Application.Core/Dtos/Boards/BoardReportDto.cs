using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Dtos.Tasks;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Boards
{
    public class BoardReportDto: TaskReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.CardsCount), ResourceType = typeof(ApplicationMetadata))]
        public int CardsCount { get; set; }
    }
}

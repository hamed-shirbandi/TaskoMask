using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Boards
{
    public class BoardReportDto: TaskReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.CardsCount), ResourceType = typeof(ApplicationMetadata))]
        public long CardsCount { get; set; }


    }
}

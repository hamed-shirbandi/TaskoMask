using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Cards
{
    public class CardReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.TasksCount), ResourceType = typeof(ApplicationMetadata))]
        public int TasksCount { get; set; }
    }
}

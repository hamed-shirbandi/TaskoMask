using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Workspace.Cards
{
    public class CardOutputDto : CardBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.BoardName), ResourceType = typeof(ApplicationMetadata))]
        public string BoardName { get; set; }

        [Display(Name = nameof(ApplicationMetadata.TasksCount), ResourceType = typeof(ApplicationMetadata))]
        public long TasksCount { get; set; }
    }
}

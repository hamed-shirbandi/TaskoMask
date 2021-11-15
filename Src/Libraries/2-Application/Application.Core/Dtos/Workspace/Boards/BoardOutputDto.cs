using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Workspace.Boards
{
    public class BoardOutputDto : BoardBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.ProjectName), ResourceType = typeof(ApplicationMetadata))]
        public string ProjectName { get; set; }

        [Display(Name = nameof(ApplicationMetadata.CardsCount), ResourceType = typeof(ApplicationMetadata))]
        public long CardsCount { get; set; }
    }
}

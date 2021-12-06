using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Boards
{
    public class BoardOutputDto : BoardBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.ProjectName), ResourceType = typeof(ApplicationMetadata))]
        public string ProjectName { get; set; }

        [Display(Name = nameof(ApplicationMetadata.CardsCount), ResourceType = typeof(ApplicationMetadata))]
        public long CardsCount { get; set; }
    }
}

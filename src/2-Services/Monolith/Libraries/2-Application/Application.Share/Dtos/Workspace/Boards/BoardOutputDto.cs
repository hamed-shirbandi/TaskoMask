using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Application.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Boards
{
    public class BoardOutputDto : BoardBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.ProjectName), ResourceType = typeof(ApplicationMetadata))]
        public string ProjectName { get; set; }

        [Display(Name = nameof(ApplicationMetadata.OrganizationName), ResourceType = typeof(ApplicationMetadata))]
        public string OrganizationName { get; set; }


    }
}

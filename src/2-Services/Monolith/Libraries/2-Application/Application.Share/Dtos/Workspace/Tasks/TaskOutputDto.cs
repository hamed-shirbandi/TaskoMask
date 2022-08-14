using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Application.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Tasks
{
    public class TaskOutputDto: TaskBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.OrganizationName), ResourceType = typeof(ApplicationMetadata))]
        public string CardName { get; set; }
    }
}

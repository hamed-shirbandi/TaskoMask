using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Dtos.Workspace.Tasks;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Workspace.Boards
{
    public class BoardReportDto: TaskReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.CardsCount), ResourceType = typeof(ApplicationMetadata))]
        public int CardsCount { get; set; }

        [Display(Name = nameof(ApplicationMetadata.MembersCount), ResourceType = typeof(ApplicationMetadata))]
        public int InvitedMembersCount { get; set; }
    }
}

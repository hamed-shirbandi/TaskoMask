using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Activities;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Comments;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Tasks;

namespace TaskoMask.Services.Monolith.Application.Share.ViewModels
{
    public class TaskDetailsViewModel
    {
        public TaskBasicInfoDto Task { get; set; }
        public CardBasicInfoDto Card { get; set; }
        public IEnumerable<ActivityBasicInfoDto> Activities { get; set; }
        public IEnumerable<CommentBasicInfoDto> Comments { get; set; }
    }
}

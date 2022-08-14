using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Activities;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Comments;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Tasks;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
    public class TaskDetailsViewModel
    {
        public TaskBasicInfoDto Task { get; set; }
        public CardBasicInfoDto Card { get; set; }
        public IEnumerable<ActivityBasicInfoDto> Activities { get; set; }
        public IEnumerable<CommentBasicInfoDto> Comments { get; set; }
    }
}

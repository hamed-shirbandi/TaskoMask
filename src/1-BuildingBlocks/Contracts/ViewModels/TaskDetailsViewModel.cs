using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Activities;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;

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

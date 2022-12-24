using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Activities;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels
{
    public class TaskDetailsViewModel
    {
        public GetTaskDto Task { get; set; }
        public GetCardDto Card { get; set; }
        public IEnumerable<GetTaskActivityDto> Activities { get; set; }
        public IEnumerable<GetCommentDto> Comments { get; set; }
    }
}

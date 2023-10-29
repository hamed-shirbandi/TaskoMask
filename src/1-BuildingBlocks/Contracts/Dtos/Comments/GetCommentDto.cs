using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;

public class GetCommentDto : CommentBaseDto
{
    public CreationTimeDto CreationTime { get; set; }
}

using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Comments;
using TaskoMask.Services.Monolith.Application.Core.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Comments.Queries.Models
{
    public class GetCommentsByTaskIdQuery : BaseQuery<IEnumerable<CommentBasicInfoDto>>
    {
        public GetCommentsByTaskIdQuery(string taskId)
        {
            TaskId = taskId;
        }

        public string TaskId { get; }
    }
}

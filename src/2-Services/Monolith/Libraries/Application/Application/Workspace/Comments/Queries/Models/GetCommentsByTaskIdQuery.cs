using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Application.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Comments.Queries.Models
{
    public class GetCommentsByTaskIdQuery : BaseQuery<IEnumerable<GetCommentDto>>
    {
        public GetCommentsByTaskIdQuery(string taskId)
        {
            TaskId = taskId;
        }

        public string TaskId { get; }
    }
}

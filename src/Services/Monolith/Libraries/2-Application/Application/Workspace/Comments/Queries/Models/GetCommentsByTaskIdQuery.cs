using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Comments;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Comments.Queries.Models
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

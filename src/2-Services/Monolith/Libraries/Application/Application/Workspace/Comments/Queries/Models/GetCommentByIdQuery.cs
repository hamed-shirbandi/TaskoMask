using TaskoMask.Application.Share.Dtos.Workspace.Comments;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Comments.Queries.Models
{
   
    public class GetCommentByIdQuery : BaseQuery<CommentBasicInfoDto>
    {
        public GetCommentByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}

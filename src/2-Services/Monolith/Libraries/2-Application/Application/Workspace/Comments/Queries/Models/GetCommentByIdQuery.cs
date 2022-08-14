using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Comments;
using TaskoMask.Services.Monolith.Application.Core.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Comments.Queries.Models
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

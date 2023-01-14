using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentById
{
    public class GetCommentByIdRequest : BaseQuery<GetCommentDto>
    {
        public GetCommentByIdRequest(string id)
        {
            Id = id;
        }


        public string Id { get; }


    }
}

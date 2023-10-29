using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentsByTaskId;

public class GetCommentsByTaskIdRequest : BaseQuery<IEnumerable<GetCommentDto>>
{
    public GetCommentsByTaskIdRequest(string taskId)
    {
        TaskId = taskId;
    }

    public string TaskId { get; }
}

using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;

namespace TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardsByProjectId;

public class GetBoardsByProjectIdRequest : BaseQuery<IEnumerable<GetBoardDto>>
{
    public GetBoardsByProjectIdRequest(string projectId)
    {
        ProjectId = projectId;
    }

    public string ProjectId { get; }
}

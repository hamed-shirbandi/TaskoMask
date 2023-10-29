using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTaskById;

public class GetTaskByIdRequest : BaseQuery<GetTaskDto>
{
    public GetTaskByIdRequest(string id)
    {
        Id = id;
    }

    public string Id { get; }
}

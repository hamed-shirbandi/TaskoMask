using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;

namespace TaskoMask.Services.Owners.Read.Api.Features.Owners.GetOwnerById;

public class GetOwnerByIdRequest : BaseQuery<GetOwnerDto>
{
    public GetOwnerByIdRequest(string id)
    {
        Id = id;
    }

    public string Id { get; }
}

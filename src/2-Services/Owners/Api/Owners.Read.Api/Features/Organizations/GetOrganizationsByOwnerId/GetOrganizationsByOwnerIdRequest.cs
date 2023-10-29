using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;

namespace TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationsByOwnerId;

public class GetOrganizationsByOwnerIdRequest : BaseQuery<IEnumerable<GetOrganizationDto>>
{
    public GetOrganizationsByOwnerIdRequest(string ownerId)
    {
        OwnerId = ownerId;
    }

    public string OwnerId { get; }
}

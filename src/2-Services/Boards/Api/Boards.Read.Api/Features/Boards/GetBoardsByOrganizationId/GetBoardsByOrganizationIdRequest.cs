using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;

namespace TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardsByOrganizationId;

public class GetBoardsByOrganizationIdRequest : BaseQuery<IEnumerable<GetBoardDto>>
{
    public GetBoardsByOrganizationIdRequest(string organizationId)
    {
        OrganizationId = organizationId;
    }

    public string OrganizationId { get; }
}

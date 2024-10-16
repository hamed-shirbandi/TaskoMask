using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;

namespace TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationReportById;


public class GetOrganizationReportByIdRequest : BaseQuery<OrganizationReportDto>
{
    public GetOrganizationReportByIdRequest(string id)
    {
        Id = id;
    }

    public string Id { get; }
}

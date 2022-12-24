using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;

namespace TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationById
{
    public class GetOrganizationByIdRequest : BaseQuery<GetOrganizationDto>
    {
        public GetOrganizationByIdRequest(string id)
        {
            Id = id;
        }


        public string Id { get; }


    }
}

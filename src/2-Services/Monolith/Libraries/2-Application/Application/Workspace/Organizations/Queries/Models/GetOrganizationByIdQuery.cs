using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Organizations;
using TaskoMask.Services.Monolith.Application.Core.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Organizations.Queries.Models
{
   
    public class GetOrganizationByIdQuery : BaseQuery<OrganizationBasicInfoDto>
    {
        public GetOrganizationByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}

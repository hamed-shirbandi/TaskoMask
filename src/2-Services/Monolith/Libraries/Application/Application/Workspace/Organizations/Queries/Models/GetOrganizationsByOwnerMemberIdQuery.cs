using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Organizations;
using TaskoMask.BuildingBlocks.Application.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Organizations.Queries.Models
{
   
    public class GetOrganizationsByOwnerIdQuery : BaseQuery<IEnumerable<OrganizationBasicInfoDto>>
    {
        public GetOrganizationsByOwnerIdQuery(string ownerId)
        {
            OwnerId = ownerId;
        }

        public string OwnerId { get; }
    }
}

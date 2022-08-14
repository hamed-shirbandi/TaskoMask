using System.Collections.Generic;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Services.Monolith.Application.Core.Queries;

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

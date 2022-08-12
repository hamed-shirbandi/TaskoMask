using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Organizations.Queries.Models
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

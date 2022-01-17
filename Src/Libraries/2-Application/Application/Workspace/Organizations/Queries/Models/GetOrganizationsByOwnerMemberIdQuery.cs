using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Organizations.Queries.Models
{
   
    public class GetOrganizationsByOwnerOwnerIdQuery : BaseQuery<IEnumerable<OrganizationBasicInfoDto>>
    {
        public GetOrganizationsByOwnerOwnerIdQuery(string ownerOwnerId)
        {
            OwnerOwnerId = ownerOwnerId;
        }

        public string OwnerOwnerId { get; }
    }
}

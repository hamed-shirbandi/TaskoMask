using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Team.Organizations.Queries.Models
{
   
    public class GetOrganizationsByOwnerMemberIdQuery : BaseQuery<IEnumerable<OrganizationBasicInfoDto>>
    {
        public GetOrganizationsByOwnerMemberIdQuery(string ownerMemberId)
        {
            OwnerMemberId = ownerMemberId;
        }

        public string OwnerMemberId { get; }
    }
}

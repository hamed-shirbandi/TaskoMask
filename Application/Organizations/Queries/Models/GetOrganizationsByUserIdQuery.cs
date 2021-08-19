using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Organizations.Queries.Models
{
   
    public class GetOrganizationsByUserIdQuery : BaseQuery<IEnumerable<OrganizationBasicInfoDto>>
    {
        public GetOrganizationsByUserIdQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}

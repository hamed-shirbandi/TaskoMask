using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Organizations;

namespace TaskoMask.Application.Organizations.Queries.Models
{
   
    public class GetOrganizationsByUserIdQuery : IRequest<IEnumerable<OrganizationOutputDto>>
    {
        public GetOrganizationsByUserIdQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}

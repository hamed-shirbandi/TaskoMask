using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Organizations;

namespace TaskoMask.Application.Organizations.Queries.Models
{
   
    public class GetOrganizationByIdQuery : IRequest<OrganizationOutputDto>
    {
        public GetOrganizationByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}

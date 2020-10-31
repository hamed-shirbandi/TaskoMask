using CSharpFunctionalExtensions;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Services.Organizations.Dto;

namespace TaskoMask.Application.Queries.Models.Organizations
{
   
    public class GetOrganizationsByUserIdQuery : IRequest<IEnumerable<OrganizationOutput>>
    {
        public GetOrganizationsByUserIdQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}

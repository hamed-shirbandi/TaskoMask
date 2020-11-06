using CSharpFunctionalExtensions;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Services.Organizations.Dto;

namespace TaskoMask.Application.Queries.Models.Organizations
{
   
    public class GetOrganizationByIdQuery : IRequest<OrganizationOutput>
    {
        public GetOrganizationByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}

using CSharpFunctionalExtensions;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Services.Projects.Dto;

namespace TaskoMask.Application.Queries.Models.Projects
{
   
    public class GetProjectsByOrganizationIdQuery : IRequest<IEnumerable<ProjectOutput>>
    {
        public GetProjectsByOrganizationIdQuery(string organizationId)
        {
            OrganizationId = organizationId;
        }

        public string OrganizationId { get; }
    }
}

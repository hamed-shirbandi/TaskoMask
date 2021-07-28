using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Projects;

namespace TaskoMask.Application.Projects.Queries.Models
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

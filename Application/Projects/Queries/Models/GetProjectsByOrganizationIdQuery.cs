using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Domain.Core.Queries;


namespace TaskoMask.Application.Projects.Queries.Models
{
   
    public class GetProjectsByOrganizationIdQuery : BaseQuery<IEnumerable<ProjectBasicInfoDto>>
    {
        public GetProjectsByOrganizationIdQuery(string organizationId)
        {
            OrganizationId = organizationId;
        }

        public string OrganizationId { get; }
    }
}

using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Team.Projects.Queries.Models
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

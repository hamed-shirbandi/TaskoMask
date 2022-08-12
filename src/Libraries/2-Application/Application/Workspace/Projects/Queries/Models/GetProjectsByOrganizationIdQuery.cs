using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Projects.Queries.Models
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

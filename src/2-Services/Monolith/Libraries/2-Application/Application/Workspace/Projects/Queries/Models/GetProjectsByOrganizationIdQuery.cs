using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Projects;
using TaskoMask.Services.Monolith.Application.Core.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.Queries.Models
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

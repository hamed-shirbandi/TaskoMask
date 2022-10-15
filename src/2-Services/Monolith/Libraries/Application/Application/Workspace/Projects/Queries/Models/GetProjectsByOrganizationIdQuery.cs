using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Application.Queries;

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

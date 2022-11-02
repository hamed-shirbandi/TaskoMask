using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;

namespace TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectsByOrganizationId
{
    public class GetProjectsByOrganizationIdRequest : BaseQuery<IEnumerable<ProjectBasicInfoDto>>
    {
        public GetProjectsByOrganizationIdRequest(string organizationId)
        {
            OrganizationId = organizationId;
        }

        public string OrganizationId { get; }

    }
}

using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Organizations.Queries.Models
{

    public class GetOrganizationReportQuery : BaseQuery<OrganizationReportDto>
    {
        public GetOrganizationReportQuery(string organizationId)
        {
            OrganizationId = organizationId;
        }

        public string OrganizationId { get; }
    }
}

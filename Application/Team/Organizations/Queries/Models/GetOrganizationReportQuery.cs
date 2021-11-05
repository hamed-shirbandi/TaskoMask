using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Team.Organizations.Queries.Models
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

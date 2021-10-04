using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Organizations.Queries.Models
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

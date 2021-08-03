using MediatR;
using TaskoMask.Application.Core.Dtos.Organizations;

namespace TaskoMask.Application.Organizations.Queries.Models
{

    public class GetOrganizationReportQuery : IRequest<OrganizationReportDto>
    {
        public GetOrganizationReportQuery(string organizationId)
        {
            OrganizationId = organizationId;
        }

        public string OrganizationId { get; }
    }
}

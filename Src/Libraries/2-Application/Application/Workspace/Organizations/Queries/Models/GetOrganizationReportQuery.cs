using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Organizations.Queries.Models
{

    public class GetOrganizationReportQuery : BaseQuery<OrganizationReportDto>
    {
        public GetOrganizationReportQuery(string organizationId, string[] projectsId, string[] boardsId)
        {
            OrganizationId = organizationId;
            ProjectsId = projectsId;
            BoardsId = boardsId;
        }

        public string OrganizationId { get; }
        public string[] ProjectsId { get; }
        public string[] BoardsId { get; }
    }
}

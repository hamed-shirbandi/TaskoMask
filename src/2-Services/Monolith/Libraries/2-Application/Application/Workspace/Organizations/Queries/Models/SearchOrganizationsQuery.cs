using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Application.Core.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Organizations.Queries.Models
{
    public class SearchOrganizationsQuery : BaseQuery<PaginatedListReturnType<OrganizationOutputDto>>
    {
        public SearchOrganizationsQuery(int page, int recordsPerPage, string term)
        {
            Page = page;
            RecordsPerPage = recordsPerPage;
            Term = term;
        }

        public int Page { get; }
        public int RecordsPerPage { get; }
        public string Term { get; }
    }
}

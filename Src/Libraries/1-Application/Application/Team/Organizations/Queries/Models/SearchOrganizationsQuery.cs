using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Team.Organizations.Queries.Models
{
    public class SearchOrganizationsQuery:BaseQuery<PublicPaginatedListReturnType<OrganizationOutputDto>>
    {
        public SearchOrganizationsQuery(int page, int recordsPerPage, string term)
        {
            Page = page;
            RecordsPerPage = recordsPerPage;
            Term = term;
        }

        public int Page { get; set; }
        public int RecordsPerPage { get; set; }
        public string Term { get; set; }
    }
}

using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Application.Core.Queries;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Organizations.Queries.Models
{
    public class SearchOrganizationsQuery : BaseQuery<PaginatedList<OrganizationOutputDto>>
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

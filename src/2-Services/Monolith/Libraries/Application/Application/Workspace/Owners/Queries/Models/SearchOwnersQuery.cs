using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Owners.Queries.Models
{
    public class SearchOwnersQuery:BaseQuery<PaginatedList<OwnerOutputDto>>
    {
        public SearchOwnersQuery(int page, int recordsPerPage, string term)
        {
            Page = page;
            RecordsPerPage = recordsPerPage;
            Term = term;
        }

        public int Page { get;}
        public int RecordsPerPage { get; }
        public string Term { get; }
    }
}

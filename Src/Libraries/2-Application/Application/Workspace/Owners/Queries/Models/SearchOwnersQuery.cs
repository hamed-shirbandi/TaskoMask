using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Owners.Queries.Models
{
   public class SearchOwnersQuery:BaseQuery<PaginatedListReturnType<OwnerOutputDto>>
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

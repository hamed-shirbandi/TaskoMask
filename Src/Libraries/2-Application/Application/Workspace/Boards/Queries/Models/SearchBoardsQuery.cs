using TaskoMask.Application.Core.Dtos.Workspace.Boards;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Boards.Queries.Models
{
    public class SearchBoardsQuery:BaseQuery<PublicPaginatedListReturnType<BoardOutputDto>>
    {
        public SearchBoardsQuery(int page, int recordsPerPage, string term)
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

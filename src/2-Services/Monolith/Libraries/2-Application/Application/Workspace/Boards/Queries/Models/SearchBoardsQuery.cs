using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Application.Core.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Boards.Queries.Models
{
    public class SearchBoardsQuery : BaseQuery<PaginatedListReturnType<BoardOutputDto>>
    {
        public SearchBoardsQuery(int page, int recordsPerPage, string term)
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

using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Tasks.Queries.Models
{
    public class SearchTasksQuery : BaseQuery<PaginatedListReturnType<TaskOutputDto>>
    {
        public SearchTasksQuery(int page, int recordsPerPage, string term)
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

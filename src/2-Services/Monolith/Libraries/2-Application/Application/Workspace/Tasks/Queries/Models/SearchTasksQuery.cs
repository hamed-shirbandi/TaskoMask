using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Application.Core.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Queries.Models
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

using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Queries.Models
{
    public class SearchTasksQuery : BaseQuery<PaginatedList<GetTaskDto>>
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

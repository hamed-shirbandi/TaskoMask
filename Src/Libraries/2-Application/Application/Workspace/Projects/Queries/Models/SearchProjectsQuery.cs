using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Projects.Queries.Models
{
    public class SearchProjectsQuery:BaseQuery<PaginatedListReturnType<ProjectOutputDto>>
    {
        public SearchProjectsQuery(int page, int recordsPerPage, string term)
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

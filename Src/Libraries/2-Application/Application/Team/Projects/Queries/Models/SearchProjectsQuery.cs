using TaskoMask.Application.Core.Dtos.Team.Projects;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Team.Projects.Queries.Models
{
    public class SearchProjectsQuery:BaseQuery<PublicPaginatedListReturnType<ProjectOutputDto>>
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

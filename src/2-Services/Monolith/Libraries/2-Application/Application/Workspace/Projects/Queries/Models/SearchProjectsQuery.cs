using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Projects;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Application.Core.Queries;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.Queries.Models
{
    public class SearchProjectsQuery:BaseQuery<PaginatedList<ProjectOutputDto>>
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

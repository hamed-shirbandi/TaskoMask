using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Application.Core.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Queries.Models
{
    public class SearchCardsQuery : BaseQuery<PaginatedListReturnType<CardOutputDto>>
    {
        public SearchCardsQuery(int page, int recordsPerPage, string term)
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

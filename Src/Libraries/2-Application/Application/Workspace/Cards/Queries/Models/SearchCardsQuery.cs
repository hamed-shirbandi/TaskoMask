using TaskoMask.Application.Core.Dtos.Workspace.Cards;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Cards.Queries.Models
{
    public class SearchCardsQuery:BaseQuery<PublicPaginatedListReturnType<CardOutputDto>>
    {
        public SearchCardsQuery(int page, int recordsPerPage, string term)
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

using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Queries.Models
{
    public class SearchCardsQuery : BaseQuery<PaginatedList<GetCardDto>>
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

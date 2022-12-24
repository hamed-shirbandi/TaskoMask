using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Application.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Queries.Models
{
   
    public class GetCardsByBoardIdQuery : BaseQuery<IEnumerable<GetCardDto>>
    {
        public GetCardsByBoardIdQuery(string boardId)
        {
            BoardId = boardId;
        }

        public string BoardId { get; }
    }
}

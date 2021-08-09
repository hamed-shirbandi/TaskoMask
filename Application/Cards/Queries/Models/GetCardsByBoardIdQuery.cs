using TaskoMask.Domain.Core.Helpers;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Cards.Queries.Models
{
   
    public class GetCardsByBoardIdQuery : BaseQuery<IEnumerable<CardBasicInfoDto>>
    {
        public GetCardsByBoardIdQuery(string boardId)
        {
            BoardId = boardId;
        }

        public string BoardId { get; }
    }
}

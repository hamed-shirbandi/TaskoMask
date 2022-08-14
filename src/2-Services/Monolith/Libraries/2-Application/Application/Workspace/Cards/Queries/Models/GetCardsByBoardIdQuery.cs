using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Cards.Queries.Models
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

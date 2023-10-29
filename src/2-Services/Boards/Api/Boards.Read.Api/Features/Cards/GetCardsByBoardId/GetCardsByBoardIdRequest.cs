using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;

namespace TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardsByBoardId;

public class GetCardsByBoardIdRequest : BaseQuery<IEnumerable<GetCardDto>>
{
    public GetCardsByBoardIdRequest(string boardId)
    {
        BoardId = boardId;
    }

    public string BoardId { get; }
}

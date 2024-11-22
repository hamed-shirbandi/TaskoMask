using System.Linq;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Entities;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.Specifications;

internal class BoardMaxCardsSpecification : ISpecification<Board>
{
    /// <summary>
    ///
    /// </summary>
    public bool IsSatisfiedBy(Board board)
    {
        return board.Cards.Count() <= DomainConstValues.BOARD_MAX_CARD_COUNT;
    }
}

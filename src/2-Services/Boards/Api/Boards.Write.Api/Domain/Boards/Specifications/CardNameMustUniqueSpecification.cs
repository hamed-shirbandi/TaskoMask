using System.Linq;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Entities;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.Specifications;

internal class CardNameMustUniqueSpecification : ISpecification<Board>
{
    /// <summary>
    ///
    /// </summary>
    public bool IsSatisfiedBy(Board board)
    {
        var cards = board.Cards.ToList();

        var cardsCount = cards.Count;
        if (cardsCount < 2)
            return true;

        var distincCardsCount = cards.Select(p => p.Name).Distinct().Count();
        return cardsCount == distincCardsCount;
    }
}

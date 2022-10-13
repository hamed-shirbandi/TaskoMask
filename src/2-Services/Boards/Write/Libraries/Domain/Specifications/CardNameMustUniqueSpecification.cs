using System.Linq;
using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.Services.Boards.Write.Domain.Entities;

namespace TaskoMask.Services.Boards.Write.Domain.Specifications
{

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
}

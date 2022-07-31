using System.Linq;
using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.DomainModel.Workspace.Boards.Entities;

namespace TaskoMask.Domain.DomainModel.Workspace.Boards.Specifications
{

    internal class CardNameMustUniqueSpecification : ISpecification<Board>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Board board)
        {

            var cards = board.Cards.Where(p => p.IsDeleted == false).ToList();

            var cardsCount = cards.Count;
            if (cardsCount < 2)
                return true;

            var distincCardsCount = cards.Select(p => p.Name).Distinct().Count();
            return cardsCount == distincCardsCount;
        }
    }
}

using System.Linq;
using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Boards.Specifications
{

    internal class CardNameMustUniqueSpecification : ISpecification<Board>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Board board)
        {
            var cardsCount = board.Cards.Count;
            if (cardsCount < 2)
                return true;

            var distincCardsCount = board.Cards.Select(p => p.Name).Distinct().Count();
            return distincCardsCount == cardsCount;
        }
    }
}

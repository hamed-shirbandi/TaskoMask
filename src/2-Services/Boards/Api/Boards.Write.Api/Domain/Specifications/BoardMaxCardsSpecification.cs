using System.Linq;
using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Boards.Write.Api.Domain.Entities;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Specifications
{
    internal class BoardMaxCardsSpecification : ISpecification<Board>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Board board)
        {
            return board.Cards.Count() <= DomainConstValues.Board_Max_Card_Count;
        }
    }
}

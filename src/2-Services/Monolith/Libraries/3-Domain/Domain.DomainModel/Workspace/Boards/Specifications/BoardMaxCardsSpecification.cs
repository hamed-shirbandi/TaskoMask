using System.Linq;
using TaskoMask.Services.Monolith.Domain.Core.Specifications;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Specifications
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

using System.Linq;
using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Specifications
{
    internal class BoardMaxMembersSpecification : ISpecification<Board>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Board board)
        {
            return board.Members.Count <= DomainConstValues.Board_Max_Member_Count;
        }
    }
}

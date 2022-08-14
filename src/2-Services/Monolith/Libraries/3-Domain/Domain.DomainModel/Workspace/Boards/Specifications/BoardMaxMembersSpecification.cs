using System.Linq;
using TaskoMask.Services.Monolith.Domain.Core.Specifications;
using TaskoMask.Services.Monolith.Domain.Share.Helpers;
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

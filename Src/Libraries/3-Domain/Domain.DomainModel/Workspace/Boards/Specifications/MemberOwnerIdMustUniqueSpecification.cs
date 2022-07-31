using System.Linq;
using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.DomainModel.Workspace.Boards.Entities;

namespace TaskoMask.Domain.DomainModel.Workspace.Boards.Specifications
{

    internal class MemberOwnerIdMustUniqueSpecification : ISpecification<Board>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Board board)
        {
            var membersCount = board.Members.Count;
            if (membersCount < 2)
                return true;

            var distincMembersCount = board.Members.Select(p => p.OwnerId).Distinct().Count();
            return distincMembersCount == membersCount;
        }
    }
}

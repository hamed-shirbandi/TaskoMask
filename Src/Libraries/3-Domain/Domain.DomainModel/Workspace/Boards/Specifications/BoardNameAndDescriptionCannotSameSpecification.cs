using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Boards.Specifications
{
    internal class BoardNameAndDescriptionCannotSameSpecification : ISpecification<Board>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Board board)
        {
            return board.Name.Value.ToLower() != board.Description.Value?.ToLower();
        }
    }
}

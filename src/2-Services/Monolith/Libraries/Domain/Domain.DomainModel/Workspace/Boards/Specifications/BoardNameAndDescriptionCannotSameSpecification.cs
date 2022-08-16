using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Specifications
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

using TaskoMask.Services.Monolith.Domain.Core.Specifications;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Services;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Specifications
{
    internal class BoardNameMustUniqueSpecification : ISpecification<Board>
    {
        private readonly IBoardValidatorService _boardValidatorService;
        public BoardNameMustUniqueSpecification(IBoardValidatorService boardValidatorService)
        {
            _boardValidatorService = boardValidatorService;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Board board)
        {
            return _boardValidatorService.BoardHasUniqueName(board.Id, board.ProjectId.Value, board.Name.Value);
        }
    }
}

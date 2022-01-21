using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Services;

namespace TaskoMask.Domain.WriteModel.Workspace.Boards.Specifications
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

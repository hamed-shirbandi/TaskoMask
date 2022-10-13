using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.Services.Boards.Write.Domain.Entities;
using TaskoMask.Services.Boards.Write.Domain.Services;

namespace TaskoMask.Services.Boards.Write.Domain.Specifications
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

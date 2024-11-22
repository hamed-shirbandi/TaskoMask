using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Entities;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Services;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.Specifications;

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

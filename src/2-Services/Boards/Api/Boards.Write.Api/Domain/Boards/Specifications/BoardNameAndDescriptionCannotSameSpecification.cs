using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Entities;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.Specifications;

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

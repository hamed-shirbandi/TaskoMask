using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Data;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Entities;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.Data;

public interface IBoardAggregateRepository : IBaseAggregateRepository<Board>
{
    bool ExistBoard(string boardId, string projectId, string boardName);
    Task<Board> GetByCardIdAsync(string cardId);
}

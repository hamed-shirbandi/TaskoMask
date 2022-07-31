using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Boards.Data
{
    public interface IBoardAggregateRepository : IBaseAggregateRepository<Board>
    {
        bool ExistBoard(string boardId, string projectId, string boardName);
        Task<Board> GetByCardIdAsync(string cardId);
    }
}

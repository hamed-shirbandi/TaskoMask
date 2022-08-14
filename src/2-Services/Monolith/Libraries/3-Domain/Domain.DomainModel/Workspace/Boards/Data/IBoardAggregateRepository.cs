using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.Core.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Data
{
    public interface IBoardAggregateRepository : IBaseAggregateRepository<Board>
    {
        bool ExistBoard(string boardId, string projectId, string boardName);
        Task<Board> GetByCardIdAsync(string cardId);
    }
}

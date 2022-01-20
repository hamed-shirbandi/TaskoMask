using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Boards.Data
{
    public interface IBoardAggregateRepository : IBaseRepository<Board>
    {
        bool ExistBoard(string boardId, string boardName);
    }
}

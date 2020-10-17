using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Data
{
    public interface IBoardRepository : IRepository<Models.Board>
    {
        Task<IEnumerable<Models.Board>> GetListByBoardIdAsync(string boardId);
    }
}

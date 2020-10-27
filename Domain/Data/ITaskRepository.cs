using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Data
{
    public interface ITaskRepository : IBaseRepository<Models.Task>
    {
        Task<IEnumerable<Models.Task>> GetListByBoardIdAsync(string boardId);
    }
}

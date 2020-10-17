using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Data
{
    public interface ITaskRepository : IRepository<Models.Task>
    {
        Task<IEnumerable<Task>> GetListByBoardIdAsync(string boardId);
    }
}

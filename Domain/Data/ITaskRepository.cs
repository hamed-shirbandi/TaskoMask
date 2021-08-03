using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Data
{
    public interface ITaskRepository : IBaseRepository<Entities.Task>
    {
        Task<IEnumerable<Entities.Task>> GetListByCardIdAsync(string cardId);
    }
}

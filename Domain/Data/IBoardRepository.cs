using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Data
{
    public interface IBoardRepository : IBaseRepository<Models.Board>
    {
        Task<IEnumerable<Models.Board>> GetListByProjectIdAsync(string projectId);
        Task<bool> ExistByNameAsync(string id, string name);
    }
}

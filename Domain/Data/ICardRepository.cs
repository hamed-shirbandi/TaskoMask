using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Data
{
    public interface ICardRepository : IBaseRepository<Models.Card>
    {
        Task<IEnumerable<Models.Card>> GetListByBoardIdAsync(string boardId);
        Task<bool> ExistByNameAsync(string id, string name);
    }
}

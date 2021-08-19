using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Domain.Data
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Task<IEnumerable<Card>> GetListByBoardIdAsync(string boardId);
        Task<bool> ExistByNameAsync(string id, string name);
    }
}

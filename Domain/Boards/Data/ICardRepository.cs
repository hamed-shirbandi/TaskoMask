using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Boards.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Boards.Data
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Task<IEnumerable<Card>> GetListByBoardIdAsync(string boardId);
        Task<bool> ExistByNameAsync(string id, string name);
    }
}

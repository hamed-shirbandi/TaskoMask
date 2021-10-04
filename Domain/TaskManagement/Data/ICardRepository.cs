using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.TaskManagement.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.TaskManagement.Data
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Task<IEnumerable<Card>> GetListByBoardIdAsync(string boardId);
        Task<bool> ExistByNameAsync(string id, string name);
    }
}

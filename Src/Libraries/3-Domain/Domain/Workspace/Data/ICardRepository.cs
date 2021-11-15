using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Workspace.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Workspace.Data
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Task<IEnumerable<Card>> GetListByBoardIdAsync(string boardId);
        Task<bool> ExistByNameAsync(string id, string name);
        IEnumerable<Card> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
        Task<long> CountByBoardIdAsync(string boardId);
    }
}

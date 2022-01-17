using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Workspace.Boards.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Workspace.Boards.Data
{
    /// <summary>
    /// Must delete after adding read side DB
    /// </summary>
    public interface ICardRepository : IBaseAggregateRepository<Card>
    {
        Task<IEnumerable<Card>> GetListByBoardIdAsync(string boardId);
        Task<bool> ExistByNameAsync(string id, string name);
        IEnumerable<Card> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
        Task<long> CountByBoardIdAsync(string boardId);
    }
}

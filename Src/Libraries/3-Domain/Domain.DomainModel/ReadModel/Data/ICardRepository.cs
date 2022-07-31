using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.ReadModel.Entities;

namespace TaskoMask.Domain.ReadModel.Data
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Task<IEnumerable<Card>> GetListByBoardIdAsync(string boardId);
        IEnumerable<Card> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
        Task<long> CountByBoardIdAsync(string boardId);
        Task<string[]> GetCardsIdByBoardsIdAsync(string[] boardsId);
    }
}

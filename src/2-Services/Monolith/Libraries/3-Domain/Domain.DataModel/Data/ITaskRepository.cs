using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.Core.Data;
using TaskoMask.Services.Monolith.Domain.Share.Enums;

namespace TaskoMask.Services.Monolith.Domain.DataModel.Data
{
    public interface ITaskRepository : IBaseRepository<Entities.Task>
    {

        Task<IEnumerable<Entities.Task>> GetListByCardIdAsync(string cardId);
        Task<IEnumerable<Entities.Task>> GetListByOrganizationIdAsync(string organizationId, int takeCount, BoardCardType? cardType);
        Task<IEnumerable<Entities.Task>> GetPendingTasksByBoardsIdAsync(string[] boardsId, int takeCount);
        IEnumerable<Entities.Task> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
        Task<long> CountByCardIdAsync(string cardId);
        Task BulkUpdateCardTypeByCardIdAsync(string cardId, BoardCardType cardType);
        Task<long> CountByCardsIdAsync(string[] cardsId, BoardCardType cardType);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Workspace.Boards.Entities;

namespace TaskoMask.Domain.Workspace.Boards.Data
{
    public interface IBoardRepository : IBaseAggregateRepository<Board>
    {
        Task<IEnumerable<Board>> GetListByProjectIdAsync(string projectId);
        Task<IEnumerable<Board>> GetListByOrganizationIdAsync(string organizationId);
        Task<bool> ExistByNameAsync(string id, string name);
        Task<long> CountByProjectIdAsync(string projectId);
        IEnumerable<Board> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
    }
}

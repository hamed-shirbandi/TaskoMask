using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Boards.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Boards.Data
{
    public interface IBoardRepository : IBaseRepository<Board>
    {
        Task<IEnumerable<Board>> GetListByProjectIdAsync(string projectId);
        Task<IEnumerable<Board>> GetListByOrganizationIdAsync(string organizationId);
        Task<bool> ExistByNameAsync(string id, string name);
    }
}

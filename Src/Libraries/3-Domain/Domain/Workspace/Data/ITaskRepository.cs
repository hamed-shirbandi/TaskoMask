using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Workspace.Data
{
    public interface ITaskRepository : IBaseRepository<Entities.Task>
    {
        Task<IEnumerable<Entities.Task>> GetListByCardIdAsync(string cardId);
        Task<IEnumerable<Entities.Task>> GetListByOrganizationIdAsync(string organizationId,int takeCount);

        Task<bool> ExistByTitleAsync(string id, string title);
    }
}

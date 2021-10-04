using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Projects.Entities;

namespace TaskoMask.Domain.Projects.Data
{
    public interface IOrganizationRepository : IBaseRepository<Organization>
    {
        Task<IEnumerable<Organization>> GetListByUserIdAsync(string userId);
        Task<bool> ExistByNameAsync(string id, string name);
    }
}

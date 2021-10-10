using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Administration.Entities;

namespace TaskoMask.Domain.Administration.Data
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<bool> ExistByNameAsync(string id, string name);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Administration.Data
{
    public interface IOperatorRepository : IUserBaseRepository<Operator>
    {
        Task<long> CountByRoleIdAsync(string roleId);
        Task<IEnumerable<Operator>> GetListByRoleIdAsync(string roleId);
    }
}

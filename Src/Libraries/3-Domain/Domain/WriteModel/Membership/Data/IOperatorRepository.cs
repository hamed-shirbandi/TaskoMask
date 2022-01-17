using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Ownership.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Ownership.Data
{
    public interface IOperatorRepository : IBaseAggregateRepository<Operator>
    {
        Task<long> CountByRoleIdAsync(string roleId);
        Task<IEnumerable<Operator>> GetListByRoleIdAsync(string roleId);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Membership.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Membership.Data
{
    public interface IOperatorRepository : IBaseRepository<Operator>
    {
        Task<long> CountByRoleIdAsync(string roleId);
        Task<IEnumerable<Operator>> GetListByRoleIdAsync(string roleId);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.WriteModel.Membership.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.WriteModel.Membership.Data
{
    public interface IOperatorRepository : IBaseAggregateRepository<Operator>
    {
        Task<long> CountByRoleIdAsync(string roleId);
        Task<IEnumerable<Operator>> GetListByRoleIdAsync(string roleId);
    }
}

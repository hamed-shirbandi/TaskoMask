using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.WriteModel.Membership.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.WriteModel.Membership.Data
{
    public interface IOperatorRepository : IBaseRepository<Operator>
    {
        Task<IEnumerable<Operator>> GetListByRoleIdAsync(string roleId);
        Task<long> CountByRoleIdAsync(string roleId);
    }
}

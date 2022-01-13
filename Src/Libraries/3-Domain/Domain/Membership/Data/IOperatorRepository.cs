using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Membership.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Membership.Data
{
    public interface IOperatorRepository : IUserRepository<Operator>
    {
        Task<long> CountByRoleIdAsync(string roleId);
        Task<IEnumerable<Operator>> GetListByRoleIdAsync(string roleId);
    }
}

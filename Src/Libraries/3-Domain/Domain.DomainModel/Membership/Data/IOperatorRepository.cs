using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.DomainModel.Membership.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.DomainModel.Membership.Data
{
    public interface IOperatorRepository : IBaseRepository<Operator>
    {
        Task<IEnumerable<Operator>> GetListByRoleIdAsync(string roleId);
        Task<long> CountByRoleIdAsync(string roleId);
    }
}

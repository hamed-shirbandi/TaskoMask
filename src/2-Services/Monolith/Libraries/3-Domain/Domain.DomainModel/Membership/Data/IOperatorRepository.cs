using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;
using TaskoMask.BuildingBlocks.Domain.Data;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Data
{
    public interface IOperatorRepository : IBaseRepository<Operator>
    {
        Task<IEnumerable<Operator>> GetListByRoleIdAsync(string roleId);
        Task<long> CountByRoleIdAsync(string roleId);
    }
}

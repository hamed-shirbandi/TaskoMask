using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Team.Entities;

namespace TaskoMask.Domain.Team.Data
{
    public interface IOrganizationRepository : IBaseRepository<Organization>
    {
        Task<IEnumerable<Organization>> GetListByOwnerMemberIdAsync(string ownerMemberId);
        Task<bool> ExistByNameAsync(string id, string name);
    }
}

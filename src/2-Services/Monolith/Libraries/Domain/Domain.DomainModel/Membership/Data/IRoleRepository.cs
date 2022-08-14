using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;
using System.Collections.Generic;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Data
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<bool> ExistByNameAsync(string id, string name);
        Task<IEnumerable<Role>> GetListByIdsAsync( string[] selectedRolesId);
        Task<IEnumerable<Role>> GetListByPermissionIdAsync(string permissionId);
        Task<long> CountByPermissionIdAsync(string permissionId);

    }
}

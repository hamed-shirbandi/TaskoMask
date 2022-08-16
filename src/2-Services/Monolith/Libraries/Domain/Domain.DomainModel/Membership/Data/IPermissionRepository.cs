using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;
using TaskoMask.BuildingBlocks.Domain.Data;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Data
{
    public interface IPermissionRepository : IBaseRepository<Permission>
    {
        Task<bool> ExistBySystemNameAsync(string id, string systemName);
        Task<IEnumerable<Permission>> GetListByIdsAsync(string[] permissionsId);
        IEnumerable<Permission> Search(int page, int recordsPerPage, string term, string groupName, out int pageSize, out int totalItemCount);
    }
}

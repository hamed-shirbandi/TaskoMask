using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.WriteModel.Membership.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.WriteModel.Membership.Data
{
    public interface IPermissionRepository : IBaseRepository<Permission>
    {
        Task<bool> ExistBySystemNameAsync(string id, string systemName);
        IEnumerable<Permission> Search(int page, int recordsPerPage, string term, string groupName, out int pageSize, out int totalItemCount);
        Task<IEnumerable<Permission>> GetListByIdsAsync(string[] permissionsId);
    }
}

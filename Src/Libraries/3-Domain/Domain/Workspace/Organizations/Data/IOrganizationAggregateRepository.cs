using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Workspace.Organizations.Entities;

namespace TaskoMask.Domain.Workspace.Organizations.Data
{
    public interface IOrganizationAggregateRepository : IBaseAggregateRepository<Organization>
    {
        Task<IEnumerable<Organization>> GetListByOwnerOwnerIdAsync(string ownerOwnerId);
        Task<bool> ExistByNameAsync(string id, string ownerOwnerId, string name);
        bool ExistByName(string id, string ownerOwnerId, string name);
        Task<long> CountByOwnerOwnerIdAsync(string ownerOwnerId);
        IEnumerable<Organization> Search(int page, int recordsPerPage, string term, out int pageNumber, out int totalCount);
    }
}

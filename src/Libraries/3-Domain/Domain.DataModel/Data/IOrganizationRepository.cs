using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.DataModel.Entities;

namespace TaskoMask.Domain.DataModel.Data
{

    public interface IOrganizationRepository : IBaseRepository<Organization>
    {
        Task<IEnumerable<Organization>> GetListByOwnerIdAsync(string ownerId);
        IEnumerable<Organization> Search(int page, int recordsPerPage, string term, out int pageNumber, out int totalCount);
        Task<long> CountByOwnerIdAsync(string ownerId);
    }
}

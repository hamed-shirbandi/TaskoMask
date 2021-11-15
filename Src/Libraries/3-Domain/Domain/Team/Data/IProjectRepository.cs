using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Team.Entities;

namespace TaskoMask.Domain.Team.Data
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<IEnumerable<Project>> GetListByOrganizationIdAsync(string organizationId);
        Task<bool> ExistByNameAsync(string id, string name);
        IEnumerable<Project> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
        Task<long> CountByOrganizationAsync(string organizationId);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.ReadModel.Entities;

namespace TaskoMask.Domain.ReadModel.Data
{

    public interface IProjectRepository: IBaseRepository<Project>
    {
        Task<IEnumerable<Project>> GetListByOrganizationIdAsync(string organizationId);
        IEnumerable<Project> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
        Task<long> CountByOrganizationIdAsync(string organizationId);
    }
}

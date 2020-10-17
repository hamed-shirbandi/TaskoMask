using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Data
{
    public interface IProjectRepository : IRepository<Models.Project>
    {
        Task<IEnumerable<Models.Project>> GetListByOrganizationIdAsync(string organizationId);
    }
}

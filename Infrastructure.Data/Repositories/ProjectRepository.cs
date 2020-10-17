using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class ProjectRepository : Repository<Domain.Models.Project>, IProjectRepository
    {
        public ProjectRepository()
        {

        }
        public Task<IEnumerable<Domain.Models.Project>> GetListByOrganizationIdAsync(string organizationId)
        {
            throw new NotImplementedException();
        }
    }
}

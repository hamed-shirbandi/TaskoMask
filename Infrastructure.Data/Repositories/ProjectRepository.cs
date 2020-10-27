using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class ProjectRepository : BaseRepository<Domain.Models.Project>, IProjectRepository
    {
        public ProjectRepository(IMainDbContext dbContext) : base(dbContext)
        {

        }
        public Task<IEnumerable<Domain.Models.Project>> GetListByOrganizationIdAsync(string organizationId)
        {
            throw new NotImplementedException();
        }
    }
}

using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class ProjectRepository : BaseRepository<Domain.Models.Project>, IProjectRepository
    {
        private readonly IMongoCollection<Project> _projects;
        public ProjectRepository(IMainDbContext dbContext) : base(dbContext)
        {
            _projects = dbContext.GetCollection<Project>(); ;
        }

        public async Task<IEnumerable<Domain.Models.Project>> GetListByOrganizationIdAsync(string organizationId)
        {
            return await _projects.AsQueryable().Where(o => o.OrganizationId == organizationId).ToListAsync();

        }
    }
}

using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        #region Fields

        private readonly IMongoCollection<Project> _projects;

        #endregion

        #region Ctors

        public ProjectRepository(IMainDbContext dbContext) : base(dbContext)
        {
            _projects = dbContext.GetCollection<Project>(); ;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> ExistByNameAsync(string id, string name)
        {
            var project = await _projects.Find(e => e.Name == name).FirstOrDefaultAsync();
            return project != null && project.Id != id;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Project>> GetListByOrganizationIdAsync(string organizationId)
        {
            return await _projects.AsQueryable().Where(o => o.OrganizationId == organizationId).ToListAsync();

        }

        #endregion

        #region Private Methods



        #endregion
      
    }
}

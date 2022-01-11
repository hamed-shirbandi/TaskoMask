using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Workspace.Organizations.Data;
using TaskoMask.Domain.Workspace.Organizations.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories.Workspace
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        #region Fields

        private readonly IMongoCollection<Project> _projects;

        #endregion

        #region Ctors

        public ProjectRepository(IMongoDbContext dbContext) : base(dbContext)
        {
            _projects = dbContext.GetCollection<Project>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> ExistByNameAsync(string id, string name)
        {
            var project = await _projects.Find(e => e.Name.Value == name).FirstOrDefaultAsync();
            return project != null && project.Id != id;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Project>> GetListByOrganizationIdAsync(string organizationId)
        {
            return await _projects.AsQueryable().Where(o => o.OrganizationId.Value == organizationId).ToListAsync();

        }



        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Project> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount)
        {
            var queryable = _projects.AsQueryable();

            #region By term

            if (!string.IsNullOrEmpty(term))
            {
                queryable = queryable.Where(p => p.Name.Value.Contains(term) || p.Description.Value.Contains(term));
            }

            #endregion

            #region SortOrder

            queryable = queryable.OrderByDescending(p => p.Id);

            #endregion

            #region  Skip Take

            totalItemCount = queryable.CountAsync().Result;
            pageSize = (int)Math.Ceiling((double)totalItemCount / recordsPerPage);

            page = page > pageSize || page < 1 ? 1 : page;


            var skiped = (page - 1) * recordsPerPage;
            queryable = queryable.Skip(skiped).Take(recordsPerPage);


            #endregion

            return queryable.ToList();
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountByOrganizationIdAsync(string organizationId)
        {
            return await _projects.CountDocumentsAsync(b => b.OrganizationId.Value == organizationId);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}

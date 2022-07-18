using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Infrastructure.Data.Common.Repositories;
using TaskoMask.Infrastructure.Data.ReadModel.DbContext;

namespace TaskoMask.Infrastructure.Data.ReadModel.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        #region Fields

        private readonly IMongoCollection<Project> _projects;

        #endregion

        #region Ctors

        public ProjectRepository(IReadDbContext dbContext) : base(dbContext)
        {
            _projects = dbContext.GetCollection<Project>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Project>> GetListByOrganizationIdAsync(string organizationId)
        {
            return await _projects.AsQueryable().Where(o => o.OrganizationId == organizationId && o.IsDeleted == false).ToListAsync();

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
                queryable = queryable.Where(p => p.Name.Contains(term) || p.Description.Contains(term));
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
            return await _projects.CountDocumentsAsync(b => b.OrganizationId == organizationId && b.IsDeleted == false);
        }


        #endregion

        #region Private Methods



        #endregion

    }
}

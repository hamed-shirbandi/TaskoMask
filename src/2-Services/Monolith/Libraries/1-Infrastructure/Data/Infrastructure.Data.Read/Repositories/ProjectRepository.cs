using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Infrastructure.Data.Core.Repositories;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Read.Repositories
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
            return await _projects.AsQueryable().Where(o => o.OrganizationId == organizationId ).ToListAsync();

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

            queryable = queryable.OrderByDescending(p => p.CreationTime.CreateDateTime);

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
            return await _projects.CountDocumentsAsync(b => b.OrganizationId == organizationId );
        }


        #endregion

        #region Private Methods



        #endregion

    }
}

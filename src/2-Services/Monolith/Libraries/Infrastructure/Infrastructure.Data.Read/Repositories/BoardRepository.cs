using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Read.Repositories
{
    public class BoardRepository : MongoDbBaseRepository<Board>, IBoardRepository
    {
        #region Fields

        private readonly IMongoCollection<Board> _boards;

        #endregion

        #region Ctors

        public BoardRepository(IReadDbContext dbContext) : base(dbContext)
        {
            _boards = dbContext.GetCollection<Board>();
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Board>> GetListByProjectIdAsync(string projectId)
        {
            return await _boards.AsQueryable().Where(o => o.ProjectId == projectId ).ToListAsync();
        }





        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Board>> GetListByOrganizationIdAsync(string organizationId)
        {
            return await _boards.AsQueryable().Where(o => o.OrganizationId == organizationId ).ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Board>> GetListByProjectsIdAsync(string[] projectsId)
        {
            return await _boards.AsQueryable().Where(o => projectsId.Contains(o.ProjectId) ).ToListAsync();

        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Board> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount)
        {
            var queryable = _boards.AsQueryable();

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
        public async Task<long> CountByProjectIdAsync(string projectId)
        {
            return await _boards.CountDocumentsAsync(b => b.ProjectId == projectId);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountByProjectsIdAsync(string[] projectsId)
        {
            return await _boards.CountDocumentsAsync(b => projectsId.Contains(b.ProjectId) );
        }



        #endregion

        #region Private Methods



        #endregion

    }
}

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
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
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
            return await _boards.AsQueryable().Where(o => o.ProjectId == projectId).ToListAsync();
        }





        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Board>> GetListByOrganizationIdAsync(string organizationId)
        {
            return await _boards.AsQueryable().Where(o => o.OrganizationId == organizationId).ToListAsync();
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
        public async Task<long> CountByProjectIdAsync(string projectId)
        {
            return await _boards.CountDocumentsAsync(b => b.ProjectId == projectId);
        }



        #endregion

        #region Private Methods



        #endregion

    }
}

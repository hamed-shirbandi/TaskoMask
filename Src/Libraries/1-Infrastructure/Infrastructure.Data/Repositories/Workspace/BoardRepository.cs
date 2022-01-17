using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Workspace.Boards.Data;
using TaskoMask.Domain.Workspace.Boards.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class BoardRepository : BaseAggregateRepository<Board>, IBoardRepository
    {
        #region Fields

        private readonly IMongoCollection<Board> _boards;

        #endregion

        #region Ctors

        public BoardRepository(IMongoDbContext dbContext) : base(dbContext)
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
        public async Task<bool> ExistByNameAsync(string id, string name)
        {
            var board = await _boards.Find(e => e.Name == name).FirstOrDefaultAsync();
            return board != null && board.Id != id;
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountByProjectIdAsync(string projectId)
        {
            return await _boards.CountDocumentsAsync(b => b.ProjectId==projectId);
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


        #endregion

        #region Private Methods



        #endregion

    }
}

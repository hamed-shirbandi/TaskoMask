using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
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

        #endregion

        #region Private Methods



        #endregion

    }
}

using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        private readonly IMongoCollection<Board> _boards;
        public BoardRepository(IMainDbContext dbContext) : base(dbContext)
        {
            _boards = dbContext.GetCollection<Board>(); ;
        }


        public async Task<IEnumerable<Board>> GetListByProjectIdAsync(string projectId)
        {
            return await _boards.AsQueryable().Where(o => o.ProjectId == projectId).ToListAsync();

        }


        public async Task<bool> ExistByNameAsync(string id, string name)
        {
            var organization = await _boards.Find(e => e.Name == name).FirstOrDefaultAsync();
            return organization != null && organization.Id != id;
        }

    }
}

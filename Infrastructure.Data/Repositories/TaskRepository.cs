using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class TaskRepository : BaseRepository<Domain.Entities.Task>, ITaskRepository
    {
        private readonly IMongoCollection<Domain.Entities.Task> _tasks;

        public TaskRepository(IMainDbContext dbContext) : base(dbContext)
        {
            _tasks = dbContext.GetCollection<Domain.Entities.Task>(); ;
        }


        public async Task<IEnumerable<Domain.Entities.Task>> GetListByCardIdAsync(string cardId)
        {
            return await _tasks.AsQueryable().Where(o => o.CardId == cardId).ToListAsync();

        }



    }
}

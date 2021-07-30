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
        public TaskRepository(IMainDbContext dbContext) : base(dbContext)
        {

        }
        public Task<IEnumerable<Domain.Entities.Task>> GetListByBoardIdAsync(string boardId)
        {
            throw new NotImplementedException();
        }
    }
}

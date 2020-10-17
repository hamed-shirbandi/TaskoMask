using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class TaskRepository : Repository<Domain.Models.Task>, ITaskRepository
    {
        public Task CreateAsync(Domain.Models.Task entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Task>> GetListByBoardIdAsync(string boardId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Domain.Models.Task entity)
        {
            throw new NotImplementedException();
        }

        Task<Domain.Models.Task> IRepository<Domain.Models.Task>.GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Domain.Models.Task>> IRepository<Domain.Models.Task>.GetListAsync()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Repository()
        {

        }
        public Task CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    
        public Task<TEntity> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
         //   Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

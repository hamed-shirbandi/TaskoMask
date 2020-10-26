using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _entity;
        public Repository(IMainDbContext dbContext)
        {
            _entity = dbContext.GetCollection<TEntity>(); ;
        }

        public async Task CreateAsync(TEntity entity)
        {
           await _entity.InsertOneAsync(entity);
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

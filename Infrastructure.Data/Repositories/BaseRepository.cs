using AspNetCore.Identity.Mongo.Mongo;
using MongoDB.Bson;
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
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoCollection<TEntity> _collection;
        public BaseRepository(IMainDbContext dbContext)
        {
            _collection = dbContext.GetCollection<TEntity>(); ;
        }

        public async Task CreateAsync(TEntity entity)
        {
           await _collection.InsertOneAsync(entity);
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    
        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _collection.Find(e=>e.Id==id).FirstOrDefaultAsync();
        }

        public Task<IEnumerable<TEntity>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }


        public async Task<long> CountAsync()
        {
            return await _collection.CountDocumentsAsync(f => true);
        }

        public void Dispose()
        {
         //   Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

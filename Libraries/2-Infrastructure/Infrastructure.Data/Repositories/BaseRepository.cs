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

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _collection.Find(e=>e.Id==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync()
        {
            return await _collection.AsQueryable().ToListAsync();

        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _collection.ReplaceOneAsync(p => p.Id == entity.Id, entity, new ReplaceOptions() { IsUpsert = false });
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

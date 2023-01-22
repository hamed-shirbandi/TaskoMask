using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Data;
using TaskoMask.BuildingBlocks.Domain.Models;

namespace TaskoMask.BuildingBlocks.Infrastructure.MongoDB
{
    public class MongoDbBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        #region Fields

        private readonly IMongoCollection<TEntity> _collection;

        #endregion

        #region Ctors

        public MongoDbBaseRepository(MongoDbContext dbContext, string collectionName = "")
        {
            _collection = dbContext.GetCollection<TEntity>(collectionName);
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public virtual async Task AddAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual async Task UpdateAsync(TEntity entity)
        {
            await _collection.ReplaceOneAsync(p => p.Id == entity.Id, entity, new ReplaceOptions() { IsUpsert = false });
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<IEnumerable<TEntity>> GetListAsync()
        {
            return await _collection.AsQueryable().ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<long> CountAsync()
        {
            return await _collection.CountDocumentsAsync(f => true);
        }



        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            //   Db.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}

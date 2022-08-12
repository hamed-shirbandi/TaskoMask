﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Infrastructure.Data.Core.DbContext;

namespace TaskoMask.Infrastructure.Data.Core.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        private readonly IMongoCollection<TEntity> _collection;

        #endregion

        #region Ctors

        public BaseRepository(IMongoDbContext dbContext,string collectionName="")
        {
            _collection = dbContext.GetCollection<TEntity>(collectionName);
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public virtual async Task CreateAsync(TEntity entity)
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

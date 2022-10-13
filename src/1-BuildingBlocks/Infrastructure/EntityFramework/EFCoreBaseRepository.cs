using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Data;
using TaskoMask.BuildingBlocks.Domain.Models;

namespace TaskoMask.BuildingBlocks.Infrastructure.EntityFramework
{
    public class EFCoreBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        private readonly IUnitOfWork _uow;
        private readonly DbSet<TEntity> _entities;

        #endregion

        #region Ctors

        public EFCoreBaseRepository(IUnitOfWork uow)
        {
            _uow = uow;
            _entities = _uow.Set<TEntity>();
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public virtual async Task CreateAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual async Task UpdateAsync(TEntity entity)
        {
            _uow.MarkAsModified(entity);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            _uow.MarkAsDeleted(entity);

        }



        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            return await _entities.FirstOrDefaultAsync(e => e.Id == id);
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<IEnumerable<TEntity>> GetListAsync()
        {
            return await _entities.ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<long> CountAsync()
        {
            return await _entities.CountAsync();
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

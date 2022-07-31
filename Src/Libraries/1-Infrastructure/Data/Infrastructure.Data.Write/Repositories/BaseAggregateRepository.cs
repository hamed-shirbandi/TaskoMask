using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Infrastructure.Data.Core.Repositories;
using TaskoMask.Infrastructure.Data.Write.DbContext;

namespace TaskoMask.Infrastructure.Data.Write.Repositories
{
    public class BaseAggregateRepository<TEntity> : BaseRepository<TEntity>, IBaseAggregateRepository<TEntity> where TEntity : AggregateRoot
    {
        #region Fields

        private readonly IMongoCollection<TEntity> _collection;

        #endregion

        #region Ctors

        public BaseAggregateRepository(IWriteDbContext dbContext) : base(dbContext)
        {
            _collection = dbContext.GetCollection<TEntity>();
        }



        #endregion

        #region Public Methods





        /// <summary>
        /// 
        /// </summary>
        public async Task ConcurrencySafeUpdate(TEntity entity, string loadedVersion)
        {
            await CheckIfVersionIsChangedAndThrowExceptionAsync(entity.Id, loadedVersion);
            await _collection.ReplaceOneAsync(p => p.Id == entity.Id && p.Version == loadedVersion, entity, new ReplaceOptions() { IsUpsert = false });
        }




        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        private async Task CheckIfVersionIsChangedAndThrowExceptionAsync(string id, string loadedVersion)
        {
            var versionExist = await _collection.Find(e => e.Id == id && e.Version == loadedVersion).AnyAsync();
            if (!versionExist)
                throw new DomainException(DomainMessages.Concurrency_Error);
        }

        #endregion

    }
}

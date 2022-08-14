using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Data;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Infrastructure.Repositories;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Write.Repositories
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
                throw new DomainException(ContractsMessages.Concurrency_Error);
        }

        #endregion

    }
}

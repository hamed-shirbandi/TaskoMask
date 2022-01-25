using MongoDB.Driver;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Infrastructure.Data.Common.Repositories;
using TaskoMask.Infrastructure.Data.WriteModel.DbContext;

namespace TaskoMask.Infrastructure.Data.WriteModel.Repositories
{
    public class BaseAggregateRepository<TEntity> : BaseRepository<TEntity>, IBaseAggregateRepository<TEntity> where TEntity : AggregateRoot
    {
        #region Fields

        private readonly IMongoCollection<TEntity> _collection;

        #endregion

        #region Ctors

        public BaseAggregateRepository(IWriteDbContext dbContext):base(dbContext)
        {
            _collection = dbContext.GetCollection<TEntity>();
        }



        #endregion

        #region Public Methods





        /// <summary>
        /// 
        /// </summary>
        public async Task ConcurrencySafeUpdate(TEntity entity,string loadedVersion)
        {
            await _collection.ReplaceOneAsync(p => p.Id == entity.Id && p.Version==loadedVersion, entity, new ReplaceOptions() { IsUpsert = false });
        }


        #endregion

        #region Private Methods



        #endregion

    }
}

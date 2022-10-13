using MongoDB.Driver;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Data;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using Microsoft.EntityFrameworkCore;

namespace TaskoMask.BuildingBlocks.Infrastructure.EntityFramework
{
    public class EFCoreBaseAggregateRepository<TEntity> : EFCoreBaseRepository<TEntity>, IBaseAggregateRepository<TEntity> where TEntity : AggregateRoot
    {
        #region Fields

        private readonly IUnitOfWork _uow;
        private readonly DbSet<TEntity> _entities;

        #endregion

        #region Ctors

        public EFCoreBaseAggregateRepository(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
            _entities = _uow.Set<TEntity>();
        }



        #endregion

        #region Public Methods





        /// <summary>
        /// 
        /// </summary>
        public async Task ConcurrencySafeUpdate(TEntity entity, string loadedVersion)
        {
            await CheckIfVersionIsChangedAndThrowExceptionAsync(entity.Id, loadedVersion);
            await UpdateAsync(entity);
        }




        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        private async Task CheckIfVersionIsChangedAndThrowExceptionAsync(string id, string loadedVersion)
        {
            var versionExist = await _entities.AnyAsync(e => e.Id == id && e.Version == loadedVersion);
            if (!versionExist)
                throw new DomainException(ContractsMessages.Concurrency_Error);
        }

        #endregion

    }
}

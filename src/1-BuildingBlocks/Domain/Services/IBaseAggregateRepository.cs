using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Entities;

namespace TaskoMask.BuildingBlocks.Domain.Services;

public interface IBaseAggregateRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : AggregateRoot
{
    Task ConcurrencySafeUpdate(TEntity entity, string loadedVersion);
}

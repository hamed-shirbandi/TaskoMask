using System.Threading.Tasks;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Core.Data
{
    public interface IBaseAggregateRepository<TEntity>: IBaseRepository<TEntity> where TEntity: AggregateRoot
    {
        Task ConcurrencySafeUpdate(TEntity entity, string loadedVersion);
    }
}

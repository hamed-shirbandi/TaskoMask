using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.Core.Models;

namespace TaskoMask.Services.Monolith.Domain.Core.Data
{
    public interface IBaseAggregateRepository<TEntity>: IBaseRepository<TEntity> where TEntity: AggregateRoot
    {
        Task ConcurrencySafeUpdate(TEntity entity, string loadedVersion);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Core.Data
{
    public interface IBaseAggregateRepository<TEntity>:IDisposable where TEntity: BaseEntity
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(string id);
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<long> CountAsync();
    }
}

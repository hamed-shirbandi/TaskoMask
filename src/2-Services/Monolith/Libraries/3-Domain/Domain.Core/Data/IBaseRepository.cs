using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.Core.Models;

namespace TaskoMask.Services.Monolith.Domain.Core.Data
{
    public interface IBaseRepository<TEntity>: IDisposable where TEntity: BaseEntity
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(string id);
        Task<TEntity> GetByIdAsync(string id);
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<long> CountAsync();
    }
}

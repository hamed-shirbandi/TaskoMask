using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Models;

namespace TaskoMask.BuildingBlocks.Domain.Data
{
    public interface IBaseRepository<TEntity>: IDisposable where TEntity: Entity
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(string id);
        Task<TEntity> GetByIdAsync(string id);
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<long> CountAsync();
    }
}

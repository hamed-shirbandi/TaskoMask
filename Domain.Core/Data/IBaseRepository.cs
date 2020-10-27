using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Core.Data
{
    public interface IBaseRepository<TEntity>:IDisposable where TEntity: class
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(string id);
        Task<TEntity> GetByIdAsync(string id);
        Task<IEnumerable<TEntity>> GetListAsync();
    }
}

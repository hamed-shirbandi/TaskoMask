using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Core.Data
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        #region Read Methods


        Task<TEntity> GetByIdAsync(string id);
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<long> CountAsync();


        #endregion


        #region Write Methods


        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(string id);


        #endregion
    }
}
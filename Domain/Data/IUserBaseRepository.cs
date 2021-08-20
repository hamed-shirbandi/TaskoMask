using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Domain.Data
{
    public interface IUserBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity:User
    {
      Task<TEntity> GetByUserNameAsync(string userName);
      Task<TEntity> GetByPhoneNumberAsync(string phoneNumber);
    }
}

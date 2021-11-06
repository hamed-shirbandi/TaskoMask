using System.Threading.Tasks;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Core.Data
{
    public interface IUserRepository<TEntity> : IBaseRepository<TEntity> where TEntity:User
    {
      Task<TEntity> GetByUserNameAsync(string userName);
      Task<TEntity> GetByPhoneNumberAsync(string phoneNumber);
    }
}

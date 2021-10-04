using System.Threading.Tasks;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Core.Data
{
    public interface IUserBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity:BaseUser
    {
      Task<TEntity> GetByUserNameAsync(string userName);
      Task<TEntity> GetByPhoneNumberAsync(string phoneNumber);
    }
}

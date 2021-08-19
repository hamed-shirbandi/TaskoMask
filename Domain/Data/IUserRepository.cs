using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Domain.Data
{
    public interface IUserRepository : IBaseRepository<User>
    {
      Task<User> GetByUserNameAsync(string userName);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Authorization.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Authorization.Data
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> ExistByUserNameAsync(string userName);
        Task<User> GetByUserNameAsync(string userName);
    }
}

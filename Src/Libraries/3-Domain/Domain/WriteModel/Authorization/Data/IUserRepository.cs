using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.WriteModel.Authorization.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.WriteModel.Authorization.Data
{
    public interface IUserRepository : IBaseAggregateRepository<User>
    {
        Task<bool> ExistByUserNameAsync(string userName);
        Task<User> GetByUserNameAsync(string userName);
    }
}

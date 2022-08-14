using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Entities;
using TaskoMask.Services.Monolith.Domain.Core.Data;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Data
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> ExistByUserNameAsync(string userName);
        Task<User> GetByUserNameAsync(string userName);
    }
}

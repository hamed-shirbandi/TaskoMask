using TaskoMask.BuildingBlocks.Domain.Data;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Domain.Data
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> ExistByUserNameAsync(string userName);
        Task<User> GetByUserNameAsync(string userName);
    }
}

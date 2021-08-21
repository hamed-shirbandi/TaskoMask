using TaskoMask.Domain.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;

namespace TaskoMask.Application.Users.Services
{
    public interface IUserService : IBaseEntityService
    {
        Task<Result<UserBasicInfoDto>> GetBaseUserByIdAsync(string id);
        Task<Result<UserBasicInfoDto>> GetBaseUserByUserNameAsync(string userName);
        Task<Result<UserBasicInfoDto>> GetBaseUserByPhoneNumberAsync(string phoneNumber);
        Task<Result<bool>> ValidateUserPasswordAsync(string userName,string password);
    }
}

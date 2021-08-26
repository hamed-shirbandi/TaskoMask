using TaskoMask.Domain.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Base.Services;

namespace TaskoMask.Application.Users.Services
{
    public interface IUserService : IBaseService
    {
        Task<Result<UserBasicInfoDto>> GetBaseUserByIdAsync(string id);
        Task<Result<UserBasicInfoDto>> GetBaseUserByUserNameAsync(string userName);
        Task<Result<UserBasicInfoDto>> GetBaseUserByPhoneNumberAsync(string phoneNumber);
        Task<Result<bool>> ValidateUserPasswordAsync(string userName,string password);
    }
}

using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Common.Services;
using TaskoMask.Application.Share.Dtos.Authorization.Users;

namespace TaskoMask.Application.Authorization.Users.Services
{
    public interface IUserService : IBaseService
    {
        Task<Result<CommandResult>> CreateAsync(UserUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(UserUpsertDto input);
        Task<Result<UserBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<UserBasicInfoDto>> GetByUserNameAsync(string userName);
        Task<Result<bool>> LoginAsync(string userName,string password);
        Task<Result<CommandResult>> SetIsActiveAsync(string id, bool isActive);
        Task<Result<CommandResult>> ChangePasswordAsync(string id, string oldPassword, string newPassword);
        Task<Result<CommandResult>> ResetPasswordAsync(string id, string newPassword);

    }
}

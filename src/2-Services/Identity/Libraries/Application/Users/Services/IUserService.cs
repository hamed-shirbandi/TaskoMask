using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.Services.Identity.Application.Users.Services
{
    public interface IUserService : IApplicationService
    {
        Task<Result<UserBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<UserBasicInfoDto>> GetByUserNameAsync(string userName);
        Task<Result<bool>> IsValidCredentialAsync(string userName, string password);
        Task<Result<CommandResult>> CreateAsync(string userName, string password, UserType type);
        Task<Result<CommandResult>> UpdateUserNameAsync(string userId,string userName);
        Task<Result<CommandResult>> SetIsActiveAsync(string id, bool isActive);
        Task<Result<CommandResult>> ChangePasswordAsync(string id, string oldPassword, string newPassword);
        Task<Result<CommandResult>> ResetPasswordAsync(string id, string newPassword);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> DeleteAsync(string id);

    }
}

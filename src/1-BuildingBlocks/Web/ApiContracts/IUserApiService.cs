using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.BuildingBlocks.Web.ApiContracts
{
    public interface IUserApiService
    {
        Task<Result<CommandResult>> SetIsActive(string userId, bool isActive);
        Task<Result<CommandResult>> ChangePassword(UserChangePasswordDto input);
        Task<Result<CommandResult>> ResetPassword(UserResetPasswordDto input);
    }
}

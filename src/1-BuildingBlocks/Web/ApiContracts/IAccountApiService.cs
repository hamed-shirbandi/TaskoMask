using TaskoMask.Services.Monolith.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Services.Monolith.Application.Share.Helpers;

namespace TaskoMask.Services.Monolith.Presentation.Framework.Share.ApiContracts
{
    public interface IAccountApiService
    {
        Task<Result<UserJwtTokenDto>> Login(UserLoginDto input);
        Task<Result<UserJwtTokenDto>> Register(RegisterOwnerDto input);
    }
}

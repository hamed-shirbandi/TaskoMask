using TaskoMask.Services.Monolith.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Services.Monolith.Application.Share.Helpers;

namespace TaskoMask.BuildingBlocks.Web.ApiContracts
{
    public interface IAccountApiService
    {
        Task<Result<UserJwtTokenDto>> Login(UserLoginDto input);
        Task<Result<UserJwtTokenDto>> Register(RegisterOwnerDto input);
    }
}

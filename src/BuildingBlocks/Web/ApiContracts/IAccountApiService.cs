using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.ApiContracts
{
    public  interface IAccountApiService
    {
        Task<Result<UserJwtTokenDto>> Login(UserLoginDto input);
        Task<Result<UserJwtTokenDto>> Register(RegisterOwnerDto input);
    }
}

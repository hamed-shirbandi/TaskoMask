using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public  interface IAccountClientService
    {
        Task<Result<UserJwtTokenDto>> Login(UserLoginDto input);
        Task<Result<UserJwtTokenDto>> Register(OwnerRegisterDto input);
    }
}

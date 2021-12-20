using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public  interface IAccountClientService
    {
        Task<Result<string>> Login(UserLoginDto input);
        Task<Result<string>> Register(MemberRegisterDto input);
    }
}

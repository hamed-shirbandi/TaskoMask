using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.BuildingBlocks.Web.ApiContracts
{
    public interface IAccountApiService
    {
        Task<Result<UserJwtTokenDto>> Login(UserLoginDto input);
    }
}

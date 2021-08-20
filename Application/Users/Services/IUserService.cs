using TaskoMask.Domain.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;

namespace TaskoMask.Application.Users.Services
{
    public interface IUserService : IBaseEntityService
    {
        Task<Result<CommandResult>> CreateAsync(UserInputDto input);
        Task<Result<CommandResult>> UpdateAsync(UserInputDto input);
        Task<Result<UserBasicInfoDto>> GetAsync(string id);
        Task<Result<UserBasicInfoDto>> GetByUserNameAsync(string userName);
        Task<Result<bool>> ValidateUserPasswordAsync(string userName,string password);
    }
}

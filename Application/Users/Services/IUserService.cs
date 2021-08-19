using TaskoMask.Domain.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Services;

namespace TaskoMask.Application.Users.Services
{
    public interface IUserService : IBaseApplicationService
    {
        Task<Result<CommandResult>> CreateAsync(UserInputDto input);
        Task<Result<CommandResult>> UpdateAsync(UserInputDto input);
        Task<Result<UserBasicInfoDto>> GetAsync(string id);
        Task<Result<long>> CountAsync();
    }
}

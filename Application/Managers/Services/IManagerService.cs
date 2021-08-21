using TaskoMask.Domain.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Application.Users.Services;
using TaskoMask.Application.Core.Dtos.Managers;

namespace TaskoMask.Application.Managers.Services
{
    public interface IManagerService : IUserService
    {
        Task<Result<CommandResult>> CreateAsync(UserInputDto input);
        Task<Result<CommandResult>> UpdateAsync(UserInputDto input);
        Task<Result<ManagerBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<bool>> ValidateUserPasswordAsync(string userName,string password);
    }
}

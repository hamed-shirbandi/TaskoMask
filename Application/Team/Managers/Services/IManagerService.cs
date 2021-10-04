using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Common.BaseEntitiesUsers.Services;
using TaskoMask.Application.Core.Dtos.Managers;

namespace TaskoMask.Application.Team.Managers.Services
{
    public interface IManagerService : IBaseUserService
    {
        Task<Result<CommandResult>> CreateAsync(UserInputDto input);
        Task<Result<CommandResult>> UpdateAsync(UserInputDto input);
        Task<Result<ManagerBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<bool>> ValidateUserPasswordAsync(string userName,string password);
    }
}

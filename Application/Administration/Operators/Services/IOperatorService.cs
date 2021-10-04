using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Common.BaseEntitiesUsers.Services;
using TaskoMask.Application.Core.Dtos.Operators;

namespace TaskoMask.Application.Administration.Operators.Services
{
    public interface IOperatorService : IBaseUserService
    {
        Task<Result<CommandResult>> CreateAsync(UserInputDto input);
        Task<Result<CommandResult>> UpdateAsync(UserInputDto input);
        Task<Result<OperatorBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<bool>> ValidateUserPasswordAsync(string userName,string password);
    }
}

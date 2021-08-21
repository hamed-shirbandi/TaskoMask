using TaskoMask.Domain.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Application.Users.Services;
using TaskoMask.Application.Core.Dtos.Operators;

namespace TaskoMask.Application.Operators.Services
{
    public interface IOperatorService : IUserService
    {
        Task<Result<CommandResult>> CreateAsync(UserInputDto input);
        Task<Result<CommandResult>> UpdateAsync(UserInputDto input);
        Task<Result<OperatorBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<bool>> ValidateUserPasswordAsync(string userName,string password);
    }
}

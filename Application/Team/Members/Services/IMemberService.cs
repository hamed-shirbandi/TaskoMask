using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Common.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Common.Users.Services;
using TaskoMask.Application.Core.Dtos.Team.Members;

namespace TaskoMask.Application.Team.Members.Services
{
    public interface IMemberService : IUserService
    {
        Task<Result<CommandResult>> CreateAsync(MemberRegisterDto input);
        Task<Result<CommandResult>> UpdateAsync(UserUpsertDto input);
        Task<Result<MemberBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<bool>> ValidateUserPasswordAsync(string userName,string password);
    }
}

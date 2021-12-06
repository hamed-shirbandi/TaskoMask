using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Common.Users.Services;
using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Application.Team.Members.Services
{
    public interface IMemberService : IUserService
    {
        Task<Result<CommandResult>> CreateAsync(MemberRegisterDto input);
        Task<Result<CommandResult>> UpdateAsync(UserUpsertDto input);
        Task<Result<MemberBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<PaginatedListReturnType<MemberOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<MemberDetailsViewModel>> GetDetailsAsync(string id);
    }
}

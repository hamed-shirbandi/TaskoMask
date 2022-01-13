using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Share.Dtos.Workspace.Members;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Common.Services;

namespace TaskoMask.Application.Workspace.Members.Services
{
    public interface IMemberService : IBaseService
    {
        Task<Result<CommandResult>> CreateAsync(MemberRegisterDto input);
        Task<Result<CommandResult>> UpdateAsync(MemberUpdateDto input);
        Task<Result<MemberBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<PaginatedListReturnType<MemberOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<MemberDetailsViewModel>> GetDetailsAsync(string id);
    }
}

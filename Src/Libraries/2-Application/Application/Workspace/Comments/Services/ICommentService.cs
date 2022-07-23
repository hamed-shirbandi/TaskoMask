using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Comments;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Application.Workspace.Comments.Services
{
    public  interface ICommentService
    {
        Task<Result<CommandResult>> CreateAsync(CommentUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(CommentUpsertDto input);
        Task<Result<CommentBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<CommandResult>> DeleteAsync(string id);
    }
}

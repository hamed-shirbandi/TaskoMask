using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Comments;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Application.Workspace.Comments.Services
{
    public  interface ICommentService
    {
        Task<Result<CommentBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<IEnumerable<CommentBasicInfoDto>>> GetListByTaskIdAsync(string taskId);
        Task<Result<CommandResult>> AddAsync(UpdateCommentDto input);
        Task<Result<CommandResult>> UpdateAsync(UpdateCommentDto input);
        Task<Result<CommandResult>> DeleteAsync(string id);
    }
}

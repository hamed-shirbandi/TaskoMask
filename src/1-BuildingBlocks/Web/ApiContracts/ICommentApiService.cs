using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Comments;
using TaskoMask.Services.Monolith.Application.Share.Helpers;

namespace TaskoMask.Services.Monolith.Presentation.Framework.Share.ApiContracts
{
    public interface ICommentApiService
    {
        Task<Result<CommentBasicInfoDto>> Get(string id);
        Task<Result<CommandResult>> Add(AddCommentDto input);
        Task<Result<CommandResult>> Update(string id,UpdateCommentDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}

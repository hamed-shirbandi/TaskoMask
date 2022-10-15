using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Comments;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts
{
    public interface ICommentApiService
    {
        Task<Result<CommentBasicInfoDto>> Get(string id);
        Task<Result<CommandResult>> Add(AddCommentDto input);
        Task<Result<CommandResult>> Update(string id,UpdateCommentDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}

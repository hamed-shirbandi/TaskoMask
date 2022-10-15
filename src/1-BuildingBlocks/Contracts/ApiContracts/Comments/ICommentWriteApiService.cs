using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts.Comments
{
    public interface ICommentWriteApiService
    {
        Task<Result<CommandResult>> Add(AddCommentDto input);
        Task<Result<CommandResult>> Update(string id, UpdateCommentDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}

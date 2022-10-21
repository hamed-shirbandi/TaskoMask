using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;

namespace TaskoMask.BuildingBlocks.Contracts.Api.Comments
{
    public interface ICommentReadApiService
    {
        Task<Result<CommentBasicInfoDto>> Get(string id);

    }
}

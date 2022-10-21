using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;

namespace TaskoMask.BuildingBlocks.Contracts.Api.Boards
{
    public interface IBoardWriteApiService
    {
        Task<Result<CommandResult>> Add(AddBoardDto input);
        Task<Result<CommandResult>> Update(string id, UpdateBoardDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}

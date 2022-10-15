using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Boards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts
{
    public interface IBoardApiService
    {
        Task<Result<BoardOutputDto>> Get(string id);
        Task<Result<BoardDetailsViewModel>> GetDetails(string id);
        Task<Result<CommandResult>> Add(AddBoardDto input);
        Task<Result<CommandResult>> Update(string id, UpdateBoardDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}

using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Application.Share.ViewModels;

namespace TaskoMask.Services.Monolith.Presentation.Framework.Share.ApiContracts
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

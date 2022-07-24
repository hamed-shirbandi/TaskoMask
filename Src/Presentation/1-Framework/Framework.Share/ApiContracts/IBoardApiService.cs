using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.Framework.Share.ApiContracts
{
    public interface IBoardApiService
    {
        Task<Result<BoardOutputDto>> Get(string id);
        Task<Result<BoardDetailsViewModel>> GetDetails(string id);
        Task<Result<CommandResult>> Create(BoardCreateDto input);
        Task<Result<CommandResult>> Update(string id, BoardUpdateDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}

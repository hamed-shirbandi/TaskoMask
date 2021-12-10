using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public interface IBoardClientService
    {
        Task<Result<CommandResult>> Create(BoardUpsertDto input);
        Task<Result<BoardDetailsViewModel>> Get(string id);
        Task<Result<CommandResult>> Update(BoardUpsertDto input);
    }
}

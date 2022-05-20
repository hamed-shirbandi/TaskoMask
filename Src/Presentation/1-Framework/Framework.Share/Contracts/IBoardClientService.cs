using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public interface IBoardClientService
    {
        Task<Result<BoardBasicInfoDto>> Get(string id);
        Task<Result<CommandResult>> Create(BoardUpsertDto input);
        Task<Result<CommandResult>> Update(string id,BoardUpsertDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}

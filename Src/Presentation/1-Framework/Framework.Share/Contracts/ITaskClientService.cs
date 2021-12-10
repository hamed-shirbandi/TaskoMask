using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public interface ITaskClientService
    {
        Task<Result<CommandResult>> Create(TaskUpsertDto input);
        Task<Result<CommandResult>> SetCardId(string taskId, string cardId);
        Task<Result<CommandResult>> Update(TaskUpsertDto input);
    }
}

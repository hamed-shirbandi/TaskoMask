using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public interface ITaskClientService
    {
        Task<Result<TaskBasicInfoDto>> Get(string id);
        Task<Result<CommandResult>> Create(TaskUpsertDto input);
        Task<Result<CommandResult>> Update(string id, TaskUpsertDto input);
        Task<Result<CommandResult>> SetCardId(string taskId, string cardId);
    }
}

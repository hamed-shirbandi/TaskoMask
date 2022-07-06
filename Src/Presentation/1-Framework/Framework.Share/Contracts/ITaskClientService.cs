using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public interface ITaskClientService
    {
        Task<Result<TaskDetailsViewModel>> Get(string id);
        Task<Result<CommandResult>> Create(TaskUpsertDto input);
        Task<Result<CommandResult>> Update(string id, TaskUpsertDto input);
        Task<Result<CommandResult>> Delete(string id);
        Task<Result<CommandResult>> MoveTaskToAnotherCard(string taskId, string cardId);
    }
}

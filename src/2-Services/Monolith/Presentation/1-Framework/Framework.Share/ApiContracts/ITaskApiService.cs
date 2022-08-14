using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.Framework.Share.ApiContracts
{
    public interface ITaskApiService
    {
        Task<Result<TaskBasicInfoDto>> Get(string id);
        Task<Result<TaskDetailsViewModel>> GetDetails(string id);

        Task<Result<CommandResult>> Add(AddTaskDto input);
        Task<Result<CommandResult>> Update(string id, UpdateTaskDto input);
        Task<Result<CommandResult>> Delete(string id);
        Task<Result<CommandResult>> MoveTaskToAnotherCard(string taskId, string cardId);
    }
}

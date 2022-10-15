using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts
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

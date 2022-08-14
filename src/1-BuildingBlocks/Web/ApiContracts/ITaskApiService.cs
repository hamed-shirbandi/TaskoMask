using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Application.Share.ViewModels;

namespace TaskoMask.BuildingBlocks.Web.ApiContracts
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

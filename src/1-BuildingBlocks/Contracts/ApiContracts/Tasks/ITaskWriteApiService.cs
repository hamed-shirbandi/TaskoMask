using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts.Tasks
{
    public interface ITaskWriteApiService
    {
        Task<Result<CommandResult>> Add(AddTaskDto input);
        Task<Result<CommandResult>> Update(string id, UpdateTaskDto input);
        Task<Result<CommandResult>> Delete(string id);
        Task<Result<CommandResult>> MoveTaskToAnotherCard(string taskId, string cardId);
    }
}

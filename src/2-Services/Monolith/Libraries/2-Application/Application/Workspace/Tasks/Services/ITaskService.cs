using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Tasks;
using TaskoMask.Services.Monolith.Application.Core.Commands;
using TaskoMask.Services.Monolith.Application.Core.Services.Application;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Services
{
    public interface ITaskService : IApplicationService
    {
        Task<Result<CommandResult>> AddAsync(AddTaskDto input);
        Task<Result<CommandResult>> UpdateAsync(UpdateTaskDto input);
        Task<Result<TaskBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<TaskDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<IEnumerable<TaskBasicInfoDto>>> GetListByCardIdAsync(string cardId);
        Task<Result<PaginatedList<TaskOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> MoveTaskToAnotherCardAsync(string taskId, string cardId);
        Task<Result<CommandResult>> DeleteAsync(string id);

    }
}

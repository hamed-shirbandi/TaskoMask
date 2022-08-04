using TaskoMask.Application.Share.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Services.Application;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Application.Workspace.Tasks.Services
{
    public interface ITaskService : IApplicationService
    {
        Task<Result<CommandResult>> AddAsync(UpdateTaskDto input);
        Task<Result<CommandResult>> UpdateAsync(UpdateTaskDto input);
        Task<Result<TaskBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<TaskDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<IEnumerable<TaskBasicInfoDto>>> GetListByCardIdAsync(string cardId);
        Task<Result<PaginatedListReturnType<TaskOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> MoveTaskToAnotherCardAsync(string taskId, string cardId);
        Task<Result<CommandResult>> DeleteAsync(string id);

    }
}

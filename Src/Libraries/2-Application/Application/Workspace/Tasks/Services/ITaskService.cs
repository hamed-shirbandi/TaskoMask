using TaskoMask.Application.Share.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Common.Base.Services;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Application.Workspace.Tasks.Services
{
    public interface ITaskService : IBaseService
    {
        Task<Result<CommandResult>> CreateAsync(TaskUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(TaskUpsertDto input);
        Task<Result<TaskBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<IEnumerable<TaskBasicInfoDto>>> GetListByCardIdAsync(string cardId);
        Task<Result<PaginatedListReturnType<TaskOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<TaskDetailsViewModel>> GetDetailsAsync(string id);

    }
}

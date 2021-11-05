using TaskoMask.Application.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.TaskManagement.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Common.BaseEntities.Services;

namespace TaskoMask.Application.TaskManagement.Tasks.Services
{
    public interface ITaskService : IBaseEntityService
    {
        Task<Result<CommandResult>> CreateAsync(TaskUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(TaskUpsertDto input);
        Task<Result<TaskBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<IEnumerable<TaskBasicInfoDto>>> GetListByCardIdAsync(string cardId);
    }
}

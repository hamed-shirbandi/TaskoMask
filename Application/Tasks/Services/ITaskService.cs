using TaskoMask.Domain.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Tasks;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Services;

namespace TaskoMask.Application.Tasks.Services
{
    public interface ITaskService : IBaseApplicationService
    {
        Task<Result<CommandResult>> CreateAsync(TaskInputDto input);
        Task<Result<CommandResult>> UpdateAsync(TaskInputDto input);
        Task<Result<TaskBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<IEnumerable<TaskBasicInfoDto>>> GetListByCardIdAsync(string cardId);
    }
}

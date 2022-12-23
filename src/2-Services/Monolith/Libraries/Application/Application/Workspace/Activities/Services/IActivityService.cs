using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Activities;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.Services.Monolith.Application.Workspace.Activities.Services
{
    public interface IActivityService : IApplicationService
    {
        Task<Result<IEnumerable<GetTaskActivityDto>>> GetListByTaskIdAsync(string taskId);
    }
}

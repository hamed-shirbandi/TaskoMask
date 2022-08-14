using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Core.Services.Application;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Activities;

namespace TaskoMask.Services.Monolith.Application.Workspace.Activities.Services
{
    public interface IActivityService : IApplicationService
    {
        Task<Result<IEnumerable<ActivityBasicInfoDto>>> GetListByTaskIdAsync(string taskId);
    }
}

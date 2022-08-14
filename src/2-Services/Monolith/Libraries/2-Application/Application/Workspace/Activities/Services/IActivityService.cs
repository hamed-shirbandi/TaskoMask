using TaskoMask.Services.Monolith.Application.Share.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Core.Services.Application;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Activities;

namespace TaskoMask.Services.Monolith.Application.Workspace.Activities.Services
{
    public interface IActivityService : IApplicationService
    {
        Task<Result<IEnumerable<ActivityBasicInfoDto>>> GetListByTaskIdAsync(string taskId);
    }
}

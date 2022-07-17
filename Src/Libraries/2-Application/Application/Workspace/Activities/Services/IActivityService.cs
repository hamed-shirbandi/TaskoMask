using TaskoMask.Application.Share.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Share.Dtos.Workspace.Activities;

namespace TaskoMask.Application.Workspace.Activities.Services
{
    public interface IActivityService : IApplicationService
    {
        Task<Result<IEnumerable<ActivityBasicInfoDto>>> GetListByTaskIdAsync(string taskId);
    }
}

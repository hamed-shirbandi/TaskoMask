using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Activities;
using TaskoMask.Services.Monolith.Application.Core.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Activities.Queries.Models
{
    public class GetActivitiesByTaskIdQuery : BaseQuery<IEnumerable<ActivityBasicInfoDto>>
    {
        public GetActivitiesByTaskIdQuery(string taskId)
        {
            TaskId = taskId;
        }

        public string TaskId { get; }
    }
}

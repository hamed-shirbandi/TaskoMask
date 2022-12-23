using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Activities;
using TaskoMask.BuildingBlocks.Application.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Activities.Queries.Models
{
    public class GetActivitiesByTaskIdQuery : BaseQuery<IEnumerable<GetTaskActivityDto>>
    {
        public GetActivitiesByTaskIdQuery(string taskId)
        {
            TaskId = taskId;
        }

        public string TaskId { get; }
    }
}

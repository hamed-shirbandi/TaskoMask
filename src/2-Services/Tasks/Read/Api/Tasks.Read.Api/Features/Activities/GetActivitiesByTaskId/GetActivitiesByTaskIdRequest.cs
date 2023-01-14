using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Activities;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Activities.GetActivitiesByTaskId
{
    public class GetActivitiesByTaskIdRequest : BaseQuery<IEnumerable<GetActivityDto>>
    {
        public GetActivitiesByTaskIdRequest(string taskId)
        {
            TaskId = taskId;
        }

        public string TaskId { get; }
    }
}

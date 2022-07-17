using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Activities;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Activities.Queries.Models
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

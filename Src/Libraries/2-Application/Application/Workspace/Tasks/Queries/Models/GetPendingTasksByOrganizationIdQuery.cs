using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Share.Enums;

namespace TaskoMask.Application.Workspace.Tasks.Queries.Models
{
    public class GetPendingTasksByOrganizationIdQuery : BaseQuery<IEnumerable<TaskBasicInfoDto>>
    {
        public GetPendingTasksByOrganizationIdQuery(string organizationId,int takeCount)
        {
            OrganizationId = organizationId;
            TakeCount = takeCount;
        }

        public int TakeCount { get; }
        public string OrganizationId { get; }
    }
}

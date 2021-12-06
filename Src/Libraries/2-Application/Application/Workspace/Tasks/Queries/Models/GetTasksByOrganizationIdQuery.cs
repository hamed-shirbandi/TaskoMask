using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Tasks.Queries.Models
{
    public class GetTasksByOrganizationIdQuery : BaseQuery<IEnumerable<TaskBasicInfoDto>>
    {
        public GetTasksByOrganizationIdQuery(string organizationId,int takeCount)
        {
            OrganizationId = organizationId;
            TakeCount = takeCount;
        }

        public int TakeCount { get; }
        public string OrganizationId { get; }
    }
}

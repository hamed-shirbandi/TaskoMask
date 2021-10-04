using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Tasks;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.TaskManagement.Tasks.Queries.Models
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

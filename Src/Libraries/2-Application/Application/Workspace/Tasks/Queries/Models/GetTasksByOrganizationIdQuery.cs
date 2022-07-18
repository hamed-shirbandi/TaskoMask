using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Share.Enums;

namespace TaskoMask.Application.Workspace.Tasks.Queries.Models
{
    public class GetTasksByOrganizationIdQuery : BaseQuery<IEnumerable<TaskBasicInfoDto>>
    {
        public GetTasksByOrganizationIdQuery(string organizationId,int takeCount, BoardCardType? cardType)
        {
            OrganizationId = organizationId;
            TakeCount = takeCount;
            CardType = cardType;
        }

        public int TakeCount { get; }
        public string OrganizationId { get; }
        public BoardCardType? CardType { get; }
    }
}

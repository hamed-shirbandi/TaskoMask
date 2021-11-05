using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.TaskManagement.Boards;
using TaskoMask.Application.Core.Queries;


namespace TaskoMask.Application.TaskManagement.Boards.Queries.Models
{
   
    public class GetBoardsByOrganizationIdQuery : BaseQuery<IEnumerable<BoardBasicInfoDto>>
    {
        public GetBoardsByOrganizationIdQuery(string organizationId)
        {
            OrganizationId = organizationId;
        }

        public string OrganizationId { get; }
    }
}

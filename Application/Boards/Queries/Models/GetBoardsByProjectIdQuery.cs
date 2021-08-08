
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.Queries;


namespace TaskoMask.Application.Boards.Queries.Models
{
   
    public class GetBoardsByProjectIdQuery : BaseQuery<IEnumerable<BoardBasicInfoDto>>
    {
        public GetBoardsByProjectIdQuery(string projectId)
        {
           ProjectId = projectId;
        }

        public string ProjectId { get; }
    }
}

using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Boards;

namespace TaskoMask.Application.Boards.Queries.Models
{
   
    public class GetBoardsByProjectIdQuery : IRequest<IEnumerable<BoardBasicInfoDto>>
    {
        public GetBoardsByProjectIdQuery(string projectId)
        {
           ProjectId = projectId;
        }

        public string ProjectId { get; }
    }
}

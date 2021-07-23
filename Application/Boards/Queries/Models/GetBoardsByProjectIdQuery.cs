using CSharpFunctionalExtensions;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Boards;

namespace TaskoMask.Application.Boards.Queries.Models
{
   
    public class GetBoardsByProjectIdQuery : IRequest<IEnumerable<BoardOutput>>
    {
        public GetBoardsByProjectIdQuery(string projectId)
        {
           ProjectId = projectId;
        }

        public string ProjectId { get; }
    }
}

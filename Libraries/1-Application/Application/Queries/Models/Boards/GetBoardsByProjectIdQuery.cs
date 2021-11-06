using CSharpFunctionalExtensions;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Services.Boards.Dto;

namespace TaskoMask.Application.Queries.Models.Boards
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

using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Boards;

namespace TaskoMask.Application.Queries.Models.Boards
{
   
    public class GetBoardByIdQuery : IRequest<BoardOutput>
    {
        public GetBoardByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}

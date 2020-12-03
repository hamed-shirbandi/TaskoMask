using CSharpFunctionalExtensions;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Services.Boards.Dto;

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

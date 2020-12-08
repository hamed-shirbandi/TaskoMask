using CSharpFunctionalExtensions;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Services.Cards.Dto;

namespace TaskoMask.Application.Queries.Models.Cards
{
   
    public class GetCardsByBoardIdQuery : IRequest<IEnumerable<CardOutput>>
    {
        public GetCardsByBoardIdQuery(string boardId)
        {
            BoardId = boardId;
        }

        public string BoardId { get; }
    }
}

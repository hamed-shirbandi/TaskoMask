using CSharpFunctionalExtensions;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Cards;

namespace TaskoMask.Application.Cards.Queries.Models
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

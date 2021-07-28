using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Cards;

namespace TaskoMask.Application.Cards.Queries.Models
{
   
    public class GetCardByIdQuery : IRequest<CardOutput>
    {
        public GetCardByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}

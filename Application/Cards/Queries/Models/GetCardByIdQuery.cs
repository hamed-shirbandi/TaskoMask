using CSharpFunctionalExtensions;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Services.Cards.Dto;

namespace TaskoMask.Application.Queries.Models.Cards
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

using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.Queries;using TaskoMask.Domain.Core.Queries;

namespace TaskoMask.Application.Cards.Queries.Models
{
   
    public class GetCardByIdQuery : BaseQuery<CardBasicInfoDto>
    {
        public GetCardByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}

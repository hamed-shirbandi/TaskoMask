using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskoMask.Application.Cards.Queries.Models
{
    public class GetCardsCountQuery:IRequest<long>
    {
        public GetCardsCountQuery()
        {

        }
    }
}

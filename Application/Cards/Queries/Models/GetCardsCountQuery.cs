using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskoMask.Application.Queries.Models.Cards
{
    public class GetCardsCountQuery:IRequest<long>
    {
        public GetCardsCountQuery()
        {

        }
    }
}

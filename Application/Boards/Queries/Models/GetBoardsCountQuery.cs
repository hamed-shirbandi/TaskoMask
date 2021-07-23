using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskoMask.Application.Boards.Queries.Models
{
    public class GetBoardsCountQuery:IRequest<long>
    {
        public GetBoardsCountQuery()
        {

        }
    }
}

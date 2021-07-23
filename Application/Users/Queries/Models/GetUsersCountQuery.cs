using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskoMask.Application.Users.Queries.Models
{
    public class GetUsersCountQuery:IRequest<long>
    {
        public GetUsersCountQuery()
        {

        }
    }
}

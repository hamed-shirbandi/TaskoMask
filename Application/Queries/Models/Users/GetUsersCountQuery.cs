using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskoMask.Application.Queries.Models.Users
{
    public class GetUsersCountQuery:IRequest<long>
    {
        public GetUsersCountQuery()
        {

        }
    }
}

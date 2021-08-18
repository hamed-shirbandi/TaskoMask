using TaskoMask.Domain.Core.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Users.Queries.Models
{
    public class GetUsersCountQuery:BaseQuery<long>
    {
        public GetUsersCountQuery()
        {

        }
    }
}

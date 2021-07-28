using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Users;

namespace TaskoMask.Application.Users.Queries.Models
{
   
    public class GetUserByIdQuery : IRequest<UserOutput>
    {
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}

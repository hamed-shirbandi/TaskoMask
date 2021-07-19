using CSharpFunctionalExtensions;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Services.Users.Dto;

namespace TaskoMask.Application.Queries.Models.Users
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

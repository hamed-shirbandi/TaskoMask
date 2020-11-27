using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Queries.Models.Users;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Queries.Handlers.Users
{
    public class GetUsersCountQueryHandler : IRequestHandler<GetUsersCountQuery, long>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersCountQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<long> Handle(GetUsersCountQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.CountAsync();
        }
    }
}

using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Queries.Models.Users;
using TaskoMask.Application.Services.Users.Dto;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Queries.Handlers.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserOutput>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserOutput> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetByIdAsync(request.Id);
            return _mapper.Map<UserOutput>(users);
        }
    }
}

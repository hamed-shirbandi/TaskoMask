using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Users.Queries.Models;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Users.Queries.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserOutput>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserOutput> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            return _mapper.Map<UserOutput>(user);
        }
    }
}

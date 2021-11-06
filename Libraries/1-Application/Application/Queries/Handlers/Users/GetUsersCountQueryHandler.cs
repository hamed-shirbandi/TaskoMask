﻿using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Queries.Models.Users;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Queries.Handlers.Users
{
    public class GetUsersCountQueryHandler : IRequestHandler<GetUsersCountQuery, long>
    {
        private readonly UserManager<User> _userManager;
        public GetUsersCountQueryHandler( UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<long> Handle(GetUsersCountQuery request, CancellationToken cancellationToken)
        {
            return  _userManager.Users.Count();
        }
    }
}

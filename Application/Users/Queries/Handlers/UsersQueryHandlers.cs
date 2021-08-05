using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Users.Queries.Models;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Application.Users.Queries.Handlers
{
    public class UsersQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetUserByIdQuery, UserBasicInfoDto>,
        IRequestHandler<GetUsersCountQuery, long>
    {
        private readonly UserManager<User> _userManager;
        public UsersQueryHandlers(IMapper mapper, UserManager<User> userManager, IMediator mediator) : base(mediator, mapper)
        {
            _userManager = userManager;
        }

        public async Task<UserBasicInfoDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);
          
            return _mapper.Map<UserBasicInfoDto>(user);
        }


        public async Task<long> Handle(GetUsersCountQuery request, CancellationToken cancellationToken)
        {
            return _userManager.Users.Count();
        }

    }
}

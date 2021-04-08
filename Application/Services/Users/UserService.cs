using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Users;
using TaskoMask.Application.Queries.Models.Users;
using TaskoMask.Application.Services.Users.Dto;
using TaskoMask.Application.ViewMoldes.Account;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Services.Users
{
    public class UserService : BaseApplicationService, IUserService
    {
        public UserService(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        { }




        public async Task<Result<CommandResult>> CreateAsync(RegisterViewModel input)
        {
            var createCommand = _mapper.Map<CreateUserCommand>(input);
            return await _mediator.Send(createCommand);
        }


        public async Task<Result<CommandResult>> UpdateAsync(UserInput input)
        {
            var updateCommand = _mapper.Map<UpdateUserCommand>(input);
            return await _mediator.Send(updateCommand);
        }

        public async Task<UserOutput> GetByIdAsync(string id)
        {
            var query = new GetUserByIdQuery(id);
            return await _mediator.Send(query);
        }


        public async Task<UserInput> GetByIdToUpdateAsync(string id)
        {
            var user = await GetByIdAsync(id);
            return _mapper.Map<UserInput>(user);
        }



        public async Task<long> CountAsync()
        {
            var query = new GetUsersCountQuery();
            return await _mediator.Send(query);
        }


    }

}

﻿using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Users;
using TaskoMask.Application.Resources;
using TaskoMask.Domain.Core.Commands;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Commands.Handlers.Users
{
    public class CreateUserCommandHandler : CommandHandler, IRequestHandler<CreateUserCommand, Result<CommandResult>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(IMapper mapper, IMediator mediator, UserManager<User> userManager) : base(mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<Result<CommandResult>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Result.Failure<CommandResult>(ApplicationMessages.Create_Failed);
            }


            var existUser = await _userManager.FindByNameAsync(request.Email);
            if (existUser!=null)
            {
                await _mediator.Publish(new DomainNotification("", ApplicationMessages.User_Email_Already_Exist));
                return Result.Failure<CommandResult>(ApplicationMessages.Create_Failed);
            }
        
            var user = _mapper.Map<User>(request);
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    await _mediator.Publish(new DomainNotification(error.Code, error.Description));

                return Result.Failure<CommandResult>(ApplicationMessages.Create_Failed);
            }

            return Result.Success(new CommandResult(user.Id.ToString(), ApplicationMessages.Create_Success));
        }
    }
}

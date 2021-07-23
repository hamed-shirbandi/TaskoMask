using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Users.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Users.Commands.Handlers
{
    public class UpdateUserCommandHandler : BaseCommandHandler, IRequestHandler<UpdateUserCommand, Result<CommandResult>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;

        public UpdateUserCommandHandler( IMediator mediator, UserManager<User> userManager) : base(mediator)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<Result<CommandResult>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                 await PublishValidationErrorsAsync(request);
                return Result.Failure<CommandResult>(ApplicationMessages.Update_Failed);
            }


            var existUser = await _userManager.FindByNameAsync(request.Email);
            if (existUser != null && existUser.Id.ToString()!=request.Id)
            {
                await _mediator.Publish(new DomainNotification("", ApplicationMessages.User_Email_Already_Exist));
                return Result.Failure<CommandResult>(ApplicationMessages.Update_Failed);
            }

            var user = await _userManager.FindByIdAsync(request.Id);

            user.SetDisplayName(request.DisplayName);
            user.SetEmail(request.Email);
            user.SetUserName(request.Email);

           var result= await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    await _mediator.Publish(new DomainNotification(error.Code, error.Description));

                return Result.Failure<CommandResult>(ApplicationMessages.Update_Failed);
            }

            return Result.Success(new CommandResult(user.Id.ToString(), ApplicationMessages.Update_Success));
        }
    }
}

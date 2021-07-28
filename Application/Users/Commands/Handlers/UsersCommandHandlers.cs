using AutoMapper;
using TaskoMask.Application.Core.Helpers;
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
    public class UsersCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateUserCommand, CommandResult>,
        IRequestHandler<UpdateUserCommand, CommandResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UsersCommandHandlers(IMapper mapper, IMediator mediator, UserManager<User> userManager) : base(mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<CommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrorAsync(request);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var existUser = await _userManager.FindByNameAsync(request.Email);
            if (existUser != null)
            {
                await PublishValidationErrorAsync(new DomainNotification("", ApplicationMessages.User_Email_Already_Exist));
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var user = _mapper.Map<User>(request);
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    await PublishValidationErrorAsync(new DomainNotification("", error.Description));

                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            return new CommandResult(ApplicationMessages.Create_Success,user.Id.ToString());
        }




        public async Task<CommandResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrorAsync(request);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }


            var existUser = await _userManager.FindByNameAsync(request.Email);
            if (existUser != null && existUser.Id.ToString() != request.Id)
            {
                await PublishValidationErrorAsync(new DomainNotification("", ApplicationMessages.User_Email_Already_Exist));
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var user = await _userManager.FindByIdAsync(request.Id);

            user.SetDisplayName(request.DisplayName);
            user.SetEmail(request.Email);
            user.SetUserName(request.Email);

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    await PublishValidationErrorAsync(new DomainNotification("", error.Description));

                return new CommandResult(ApplicationMessages.Update_Failed,request.Id);
            }

            return new CommandResult(ApplicationMessages.Update_Success,user.Id.ToString());
        }

    }
}

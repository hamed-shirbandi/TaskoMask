using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Users.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Bus;

namespace TaskoMask.Application.Users.Commands.Handlers
{
    public class UsersCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateUserCommand, CommandResult>,
        IRequestHandler<UpdateUserCommand, CommandResult>
    {
        private readonly UserManager<User> _userManager;

        public UsersCommandHandlers(IInMemoryBus inMemoryBus, UserManager<User> userManager, IDomainNotificationHandler notifications) : base(notifications)
        {
            _userManager = userManager;
        }


        public async Task<CommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!IsValid(request))
                return new CommandResult(ApplicationMessages.Create_Failed);

            var existUser = await _userManager.FindByNameAsync(request.Email);
            if (existUser != null)
            {
                NotifyValidationError(request, ApplicationMessages.User_Email_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var user = new User(displayName: request.DisplayName, email: request.Email, userName: request.Email);
            //if (!IsValid(user))
            //    return new CommandResult(ApplicationMessages.Create_Failed);

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    NotifyValidationError(request, error.Description);

                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            return new CommandResult(ApplicationMessages.Create_Success, user.Id.ToString());
        }




        public async Task<CommandResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!IsValid(request))
                return new CommandResult(ApplicationMessages.Update_Failed);


            var existUser = await _userManager.FindByNameAsync(request.Email);
            if (existUser != null && existUser.Id.ToString() != request.Id)
            {
                NotifyValidationError(request, ApplicationMessages.User_Email_Already_Exist);
                return new CommandResult(ApplicationMessages.Update_Failed);
            }

            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);


            user.Update(request.DisplayName, request.Email, request.Email);
            //if (!IsValid(user))
            //    return new CommandResult(ApplicationMessages.Update_Failed);


            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    NotifyValidationError(request, error.Description);

                return new CommandResult(ApplicationMessages.Update_Failed, request.Id);
            }

            return new CommandResult(ApplicationMessages.Update_Success, user.Id.ToString());
        }

    }
}

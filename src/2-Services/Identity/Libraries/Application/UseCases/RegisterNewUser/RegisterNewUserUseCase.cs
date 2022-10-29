using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Identity.Application.Resources;
using TaskoMask.Services.Identity.Domain.Entities;
using TaskoMask.Services.Identity.Domain.Events;

namespace TaskoMask.Services.Identity.Application.UseCases.RegisterNewUser
{
    public class RegisterNewUserUseCase : BaseCommandHandler, IRequestHandler<RegisterNewUserRequest, CommandResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly INotificationHandler _notifications;



        /// <summary>
        /// 
        /// </summary>
        public RegisterNewUserUseCase(UserManager<User> userManager, IMessageBus messageBus, IInMemoryBus inMemoryBus, INotificationHandler notifications) : base(messageBus,inMemoryBus)
        {
            _userManager = userManager;
            _notifications = notifications;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(RegisterNewUserRequest request, CancellationToken cancellationToken)
        {
            var existUser = await _userManager.FindByNameAsync(request.Email);
            if (existUser != null)
                throw new ApplicationException(ApplicationMessages.UserName_Already_Exist);

            var newUser = new User
            {
                Email = request.Email,
                UserName = request.Email,
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded)
            {
                NotifyValidationErrors(result);
                throw new ApplicationException(ContractsMessages.Create_Failed);
            }

            var registeredUser = await _userManager.FindByNameAsync(request.Email);

            await PublishDomainEventsAsync(new NewUserRegisteredEvent(registeredUser.Id, registeredUser.Email));
           
            await PublishIntegrationEventAsync(new NewUserRegistered(registeredUser.Email));
            
            return CommandResult.Create(ContractsMessages.Create_Success, registeredUser.Id);
        }



        /// <summary>
        /// 
        /// </summary>
        private void NotifyValidationErrors(IdentityResult identityResult)
        {
            var errors = identityResult.Errors.Select(e => e.Description).ToList();

            foreach (var error in errors)
                _notifications.Add(this.GetType().Name, error);
        }
    }
}

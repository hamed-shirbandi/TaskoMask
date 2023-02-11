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
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Identity.Domain.Entities;
using TaskoMask.Services.Identity.Domain.Events;

namespace TaskoMask.Services.Identity.Application.UseCases.UpdateUser
{
    public class UpdateUserUseCase : BaseCommandHandler, IRequestHandler<UpdateUserRequest, CommandResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly INotificationHandler _notifications;



        /// <summary>
        /// 
        /// </summary>
        public UpdateUserUseCase(UserManager<User> userManager, IMessageBus messageBus, IInMemoryBus inMemoryBus, INotificationHandler notifications) : base(messageBus,inMemoryBus)
        {
            _userManager = userManager;
            _notifications = notifications;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.OldEmail);
            if (user == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.User);

            user.Email = request.NewEmail;
            user.UserName = request.NewEmail;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                NotifyValidationErrors(result);
                throw new ApplicationException(ContractsMessages.Update_Failed);
            }
          
            await PublishDomainEventsAsync(new UserUpdatedEvent(user.Id, user.Email));
           
            await PublishIntegrationEventAsync(new UserUpdated(user.Email));
            
            return CommandResult.Create(ContractsMessages.Update_Success, user.Id);
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

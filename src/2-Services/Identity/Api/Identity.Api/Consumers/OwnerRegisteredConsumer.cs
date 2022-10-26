using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Domain.EventContracts.Identity;
using TaskoMask.BuildingBlocks.Domain.EventContracts.Owners;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Web.MVC.Exceptions;
using TaskoMask.Services.Identity.Application.UseCases.RegisterNewUser;

namespace TaskoMask.Services.Identity.Api.Consumers
{
    public class OwnerRegisteredConsumer : BaseConsumer<OwnerRegisteredEvent>
    {


        public OwnerRegisteredConsumer(IInMemoryBus inMemoryBus, INotificationHandler notifications, IMessageBus messageBus) : base(inMemoryBus, notifications, messageBus)
        {
        }


        public override async Task ConsumeMessage(ConsumeContext<OwnerRegisteredEvent> context)
        {
            var registerNewUser = new RegisterNewUserRequest(context.Message.Email, context.Message.Password);
            var result = await SendCommandAsync(registerNewUser);
            if (result.IsSuccess)
                await _messageBus.Publish(new NewUserRegisteredEvent(result.Value.EntityId, context.Message.Email, context.Message.Email));
            else
                // Cause to publish Fault<OwnerRegisteredEvent> message
                throw new ConsumerFaultException(result.Message);

        }
    }
}

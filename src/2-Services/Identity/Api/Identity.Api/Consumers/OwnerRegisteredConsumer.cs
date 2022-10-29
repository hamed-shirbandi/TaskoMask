using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Web.MVC.Exceptions;
using TaskoMask.Services.Identity.Application.UseCases.RegisterNewUser;
using TaskoMask.BuildingBlocks.Contracts.Events;

namespace TaskoMask.Services.Identity.Api.Consumers
{
    /// <summary>
    /// After registering an owner, we must register a user for that owner to handle its identity (login,logout,etc)
    /// </summary>
    public class OwnerRegisteredConsumer : BaseConsumer<OwnerRegistered>
    {


        public OwnerRegisteredConsumer(IInMemoryBus inMemoryBus, INotificationHandler notifications) : base(inMemoryBus, notifications)
        {
        }


        public override async Task ConsumeMessage(ConsumeContext<OwnerRegistered> context)
        {
            var registerNewUser = new RegisterNewUserRequest(context.Message.Email, context.Message.Password);
            var result = await SendCommandAsync(registerNewUser);
            if (!result.IsSuccess)
                throw new ConsumerFaultException(result.Message); // Cause to publish Fault<OwnerRegistered> message
        }
    }
}

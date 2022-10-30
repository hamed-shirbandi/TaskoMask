using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Web.MVC.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Identity.Application.UseCases.UpdateUser;

namespace TaskoMask.Services.Identity.Api.Consumers
{
    /// <summary>
    /// After registering an owner, we must register a user for that owner to handle its identity (login,logout,etc)
    /// </summary>
    public class OwnerProfileUpdatedConsumer : BaseConsumer<OwnerProfileUpdated>
    {


        public OwnerProfileUpdatedConsumer(IInMemoryBus inMemoryBus) : base(inMemoryBus)
        {
        }


        public override async Task ConsumeMessage(ConsumeContext<OwnerProfileUpdated> context)
        {
            var registerUser = new UpdateUserRequest(context.Message.OldEmail, context.Message.NewEmail);
            var result = await _inMemoryBus.SendCommand(registerUser);
            if (!result.IsSuccess)
                throw new ConsumerFaultException(result.Message); // Cause to publish Fault<OwnerProfileUpdated> message
        }
    }
}

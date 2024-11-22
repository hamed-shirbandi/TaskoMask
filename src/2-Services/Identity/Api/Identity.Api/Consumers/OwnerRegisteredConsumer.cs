using System.Threading.Tasks;
using MassTransit;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Web.MVC.Exceptions;
using TaskoMask.Services.Identity.Api.UseCases.RegisterUser;

namespace TaskoMask.Services.Identity.Api.Consumers;

/// <summary>
/// After registering an owner, we must register a user for that owner to handle its identity (login,logout,etc)
/// </summary>
public class OwnerRegisteredConsumer : BaseConsumer<OwnerRegistered>
{
    public OwnerRegisteredConsumer(IRequestDispatcher requestDispatcher)
        : base(requestDispatcher) { }

    public override async Task ConsumeMessage(ConsumeContext<OwnerRegistered> context)
    {
        var registerUser = new RegisterUserRequest(context.Message.Id, context.Message.Email, context.Message.Password);
        var result = await _requestDispatcher.SendCommand(registerUser);
        if (!result.IsSuccess)
            throw new MessageConsumerFaultException(result.Message); // Cause to publish Fault<OwnerRegistered> message
    }
}

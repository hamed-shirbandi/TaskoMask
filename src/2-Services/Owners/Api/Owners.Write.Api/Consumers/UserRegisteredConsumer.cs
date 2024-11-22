using System.Threading.Tasks;
using MassTransit;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Data;

namespace TaskoMask.Services.Owners.Write.Api.Consumers;

/// <summary>
/// OwnerRegistered consume by identity service and it publish UserRegistered after registering user for the owner
/// it means everything is ok about the current owner registration and now we must publish OwnerRegisterationCompleted to be consumed by
/// owner read service for updating its database
/// </summary>
public class UserRegisteredConsumer : BaseConsumer<UserRegistered>
{
    private readonly IOwnerAggregateRepository _ownerAggregateRepository;

    public UserRegisteredConsumer(IRequestDispatcher requestDispatcher, IOwnerAggregateRepository ownerAggregateRepository)
        : base(requestDispatcher)
    {
        _ownerAggregateRepository = ownerAggregateRepository;
    }

    public override async Task ConsumeMessage(ConsumeContext<UserRegistered> context)
    {
        var owner = await _ownerAggregateRepository.GetByEmailAsync(context.Message.Email);

        await context.Publish(new OwnerRegisterationCompleted(owner.Id, owner.Email.Value, owner.DisplayName.Value));
    }
}

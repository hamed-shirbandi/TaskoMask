using System.Threading.Tasks;
using MassTransit;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Data;

namespace TaskoMask.Services.Owners.Write.Api.Consumers;

/// <summary>
/// OwnerProfileUpdated consume by identity service and it publish UserUpdated after registering user for the owner
/// it means everything is ok about the current owner registration and now we must publish OwnerUpdatingProfileCompleted to be consumed by
/// owner read service for updating its database
/// </summary>
public class UserUpdatedConsumer : BaseConsumer<UserUpdated>
{
    private readonly IOwnerAggregateRepository _ownerAggregateRepository;

    public UserUpdatedConsumer(IRequestDispatcher requestDispatcher, IOwnerAggregateRepository ownerAggregateRepository)
        : base(requestDispatcher)
    {
        _ownerAggregateRepository = ownerAggregateRepository;
    }

    public override async Task ConsumeMessage(ConsumeContext<UserUpdated> context)
    {
        var owner = await _ownerAggregateRepository.GetByEmailAsync(context.Message.Email);

        await context.Publish(new OwnerUpdatingProfileCompleted(owner.Id, owner.Email.Value, owner.DisplayName.Value));
    }
}

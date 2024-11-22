using System.Threading.Tasks;
using MassTransit;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Data;

namespace TaskoMask.Services.Owners.Write.Api.Consumers;

/// <summary>
/// Fault OwnerRegistered happen when identity service cant consume OwnerRegistered
/// for registering a user record for the registered owner
/// so the registered owner must be deleted from the database of ower write service
/// </summary>
public class FaultOwnerRegisteredConsumer : BaseConsumer<Fault<OwnerRegistered>>
{
    private readonly IOwnerAggregateRepository _ownerAggregateRepository;

    public FaultOwnerRegisteredConsumer(IRequestDispatcher requestDispatcher, IOwnerAggregateRepository ownerAggregateRepository)
        : base(requestDispatcher)
    {
        _ownerAggregateRepository = ownerAggregateRepository;
    }

    public override async Task ConsumeMessage(ConsumeContext<Fault<OwnerRegistered>> context)
    {
        await _ownerAggregateRepository.DeleteAsync(context.Message.Message.Id);
    }
}

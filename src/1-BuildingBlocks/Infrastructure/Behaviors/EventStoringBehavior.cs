using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Infrastructure.Services.EventStoring;

namespace TaskoMask.BuildingBlocks.Infrastructure.Behaviors;

/// <summary>
/// This behavior ensures that every command's resulting domain events are saved in the event store.
///
/// The EventStoringBehavior acts as a notification handler for domain events, abstracting the logic for
/// persisting events. This prevents the need to repeatedly implement event storage logic in multiple places.
///
/// Additionally, domain events can have other handlers for various purposes, such as:
/// - Sending notifications (e.g., emails)
/// - Updating other entities or performing additional business logic
/// This behavior specifically focuses on saving events to the event store.
/// </summary>
public class EventStoringBehavior : INotificationHandler<DomainEvent>
{
    #region Fields

    private readonly IEventStoreService _eventStore;

    #endregion

    #region Ctors


    public EventStoringBehavior(IEventStoreService eventStore)
    {
        _eventStore = eventStore;
    }

    #endregion

    #region Public Methods


    /// <summary>
    ///
    /// </summary>
    public async Task Handle(DomainEvent request, CancellationToken cancellationToken)
    {
        await _eventStore.SaveAsync(request);
    }

    #endregion

    #region Private Methods



    #endregion
}

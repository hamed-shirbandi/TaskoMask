using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Events;

namespace TaskoMask.BuildingBlocks.Infrastructure.Behaviors;

/// <summary>
/// Each command must have at least one event to save its changes in event store
/// So this notification handler act as a behavior and makes it easy to store events without repeating the creation of event handler
/// However events can have other handlers to do other things like sending an email or update some other entities, etc.
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

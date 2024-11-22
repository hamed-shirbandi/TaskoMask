using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Domain.Events;

namespace TaskoMask.BuildingBlocks.Application.Commands;

/// <summary>
///
/// </summary>
public abstract class BaseCommandHandler
{
    #region Fields


    private readonly IEventPublisher _eventPublisher;
    private readonly IRequestDispatcher _requestDispatcher;

    #endregion

    #region Ctors


    protected BaseCommandHandler(IEventPublisher eventPublisher, IRequestDispatcher requestDispatcher)
    {
        _eventPublisher = eventPublisher;
        _requestDispatcher = requestDispatcher;
    }

    #endregion

    #region Protected Methods



    /// <summary>
    /// Publishes a collection of domain events (in-process).
    /// </summary>
    protected async Task PublishDomainEventsAsync(IReadOnlyCollection<DomainEvent> domainEvents)
    {
        foreach (var domainEvent in domainEvents)
            await PublishDomainEventAsync(domainEvent);
    }

    /// <summary>
    /// Publishes a single domain event (in-process).
    /// </summary>
    protected async Task PublishDomainEventAsync(DomainEvent domainEvent)
    {
        await _requestDispatcher.PublishEvent(domainEvent);
    }

    /// <summary>
    /// Publishes an integration event (out-process).
    /// </summary>
    protected async Task PublishIntegrationEventAsync<TEvent>(TEvent @event)
        where TEvent : IIntegrationEvent
    {
        await _eventPublisher.Publish(@event);
    }

    #endregion

    #region Private Methods






    #endregion
}

using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Events;

namespace TaskoMask.BuildingBlocks.Application.Services;

/// <summary>
/// Publishes integration events for communication between microservices (out-process).
/// </summary>
public interface IEventPublisher
{
    Task Publish<TEvent>(TEvent @event)
        where TEvent : IIntegrationEvent;
}

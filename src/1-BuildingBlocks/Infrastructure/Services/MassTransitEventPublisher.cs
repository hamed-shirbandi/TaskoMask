using System.Threading.Tasks;
using MassTransit;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;

namespace TaskoMask.BuildingBlocks.Infrastructure.Services;

/// <summary>
/// Implementation of IEventPublisher using MassTransit.
/// </summary>
public class MassTransitEventPublisher : IEventPublisher
{
    #region Fields

    private readonly IPublishEndpoint _publishEndpoint;

    #endregion

    #region Ctors

    public MassTransitEventPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    #endregion

    #region Public Methods




    /// <summary>
    ///
    /// </summary>
    public async Task Publish<TEvent>(TEvent @event)
        where TEvent : IIntegrationEvent
    {
        await _publishEndpoint.Publish(@event);
    }

    #endregion

    #region Private Methods



    #endregion
}

using System.Threading.Tasks;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseCommandHandler
    {
        #region Fields


        private readonly IMessageBus _messageBus;
        private readonly IInMemoryBus _inMemoryBus;


        #endregion

        #region Ctors


        protected BaseCommandHandler(IMessageBus messageBus, IInMemoryBus inMemoryBus)
        {
            _messageBus = messageBus;
            _inMemoryBus = inMemoryBus;
        }


        #endregion

        #region Protected Methods



        /// <summary>
        /// publish domain events (in-process)
        /// </summary>
        protected async Task PublishDomainEventsAsync(IReadOnlyCollection<DomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
                await PublishDomainEventsAsync(domainEvent);
        }




        /// <summary>
        /// publish domain events (in-process)
        /// </summary>
        protected async Task PublishDomainEventsAsync(DomainEvent domainEvent)
        {
            await _inMemoryBus.PublishEvent(domainEvent);
        }





        /// <summary>
        /// publish integration events (out-process)
        /// </summary>
        protected async Task PublishIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IntegrationEvent
        {
            await _messageBus.Publish(@event);
        }


        #endregion

        #region Private Methods






        #endregion
    }
}
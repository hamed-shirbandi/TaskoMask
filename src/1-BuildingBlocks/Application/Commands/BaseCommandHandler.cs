using System.Threading.Tasks;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Application.Bus;

namespace TaskoMask.BuildingBlocks.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseCommandHandler
    {
        #region Fields


        private readonly IInMemoryBus _inMemoryBus;


        #endregion

        #region Ctors


        protected BaseCommandHandler(IInMemoryBus inMemoryBus)
        {
            _inMemoryBus = inMemoryBus;
        }


        #endregion

        #region Protected Methods



        /// <summary>
        /// publish domain events
        /// </summary>
        protected async Task PublishDomainEventsAsync(IReadOnlyCollection<DomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
                await _inMemoryBus.PublishEvent(domainEvent);
        }


        #endregion

        #region Private Methods






        #endregion
    }
}